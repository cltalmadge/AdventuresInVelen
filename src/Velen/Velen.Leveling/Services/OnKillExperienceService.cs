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

    [ScriptHandler("zol_on_death")]
    public void ResolveXpForMonsterKill(CallInfo info)
    {
        if (!NWScript.GetLastKiller().ToNwObject().IsPlayerControlled(out NwPlayer? killer))
        {
            return;
        }

        IContainer container = ContainerConfig.Configure();
        using ILifetimeScope scope = container.BeginLifetimeScope();

        if (killer.LoginCreature == null)
        {
            Log.Warn("Killer was null.");
            return;
        }

        VelenPlayer player =
            container.Resolve<VelenPlayer>(new NamedParameter("loginObjectId", killer.LoginCreature.ObjectId));

        int monsterXpValue = 0;
        int experienceToAward = _fatigueCalculator.CalculateExperience(player, monsterXpValue);
        int playerExperience = player.GetExperiencePoints();
        player.SetExperiencePoints(playerExperience + experienceToAward);
    }
}