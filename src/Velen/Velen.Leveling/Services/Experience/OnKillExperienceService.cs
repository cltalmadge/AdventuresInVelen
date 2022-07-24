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

        int monsterXpValue = MonsterXpValue(dead) * ExperienceConfig.Instance().ExperienceScale / 10;
        int partyAdjustedValue = PartyAdjustedXpValue(killer.PartyMembers, monsterXpValue);

        int experienceToAward = _fatigueCalculator.CalculateExperience(player, partyAdjustedValue);
        int playerExperience = player.GetExperiencePoints();

        player.SetExperiencePoints(playerExperience + experienceToAward);
        Log.Info("Fatigue before kill: {0}", player.Fatigue);
        player.Fatigue += (float) 0.5;
        Log.Info("Fatigue after kill: {0}", player.Fatigue);

    }

    private static int MonsterXpValue(NwCreature dead) => (int)((10 + dead.Level) * 1.8);

    private static int PartyAdjustedXpValue(IEnumerable<NwPlayer> playerPartyMembers, int monsterXpValue)
    {
        List<NwPlayer> partyMembers = playerPartyMembers.ToList();
        int partySize = partyMembers.Count;
        int averageLevel = partyMembers.Sum(partyMember => partyMember.LoginCreature!.Level) / partySize;

        double deductedXp = partySize > 1 ? averageLevel * 1.5 : 0;

        return (int)(monsterXpValue - deductedXp);
    }
}