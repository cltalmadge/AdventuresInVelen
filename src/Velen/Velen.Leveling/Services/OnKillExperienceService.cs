using Anvil.API;
using Anvil.Services;
using Autofac;
using NLog;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services;

[ServiceBinding(typeof(OnKillExperienceService))]
public class OnKillExperienceService
{
    private readonly IExperienceCalculatorService _fatigueCalculator;
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public OnKillExperienceService(IExperienceCalculatorService fatigueCalculator)
    {
        _fatigueCalculator = fatigueCalculator;
        Log.Info("OnKillExperienceService started");
    }

    [ScriptHandler("vel_on_death")]
    public void ResolveXpForMonsterKill(CallInfo info)
    {
        NwObject? lastKiller = NWScript.GetLastKiller().ToNwObject();
        NwCreature dead = (NwCreature)info.ObjectSelf!;

        if (!lastKiller.IsPlayerControlled(out NwPlayer? killer) || !lastKiller.IsValid)
        {
            return;
        }

        IContainer container = ContainerConfig.Configure();
        using ILifetimeScope scope = container.BeginLifetimeScope();
        
        VelenPlayer player =
            container.Resolve<VelenPlayer>(new NamedParameter("loginObjectId", killer.LoginCreature.ObjectId));

        int experienceToAward = _fatigueCalculator.CalculateExperience(player, MonsterXpValue(killer, dead));
        int playerExperience = player.GetExperiencePoints();

        player.SetExperiencePoints(playerExperience + experienceToAward);
    }

    private static int MonsterXpValue(NwPlayer killer, NwCreature dead)
    {
        int partySize = killer.PartyMembers.Count();
        int monsterXpValue = (int)dead.ChallengeRating * ExperienceConfig.Instance().ExperienceScale * partySize /
                             (4 / (4 + partySize - 1));
        return monsterXpValue;
    }
}