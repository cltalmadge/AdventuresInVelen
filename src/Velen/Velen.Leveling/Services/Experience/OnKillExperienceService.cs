using Anvil.API;
using Anvil.Services;
using Autofac;
using NLog;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services.Experience;

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

    [ScriptHandler("ve_def_ondeath")]
    public void ResolveXpForMonsterKill(CallInfo info)
    {
        NwObject? lastKiller = NWScript.GetLastKiller().ToNwObject();
        NwCreature dead = (NwCreature)info.ObjectSelf!;
        bool killerNotValid = !(lastKiller!.IsValid);
        bool notPlayerControlled = !lastKiller.IsPlayerControlled(out NwPlayer? killer);

        if (killerNotValid) return;

        if (notPlayerControlled)
        {
            return;
        }

        IContainer container = ContainerConfig.Configure();
        using ILifetimeScope scope = container.BeginLifetimeScope();

        VelenPlayer player =
            container.Resolve<VelenPlayer>(new NamedParameter("loginObjectId", killer!.LoginCreature!.ObjectId));

        int partyLevel = killer.PartyMembers.Sum(p => p.LoginCreature!.Level) / killer.PartyMembers.Count();
        int experienceToAward = _fatigueCalculator.CalculateExperience(player, partyLevel, (int)dead.ChallengeRating);
        int playerExperience = player.GetExperiencePoints();

        player.SetExperiencePoints(playerExperience + experienceToAward);
        player.Fatigue += (float)0.5;
    }
}