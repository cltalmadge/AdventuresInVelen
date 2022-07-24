using Anvil.API;
using Anvil.API.Events;
using Anvil.Services;
using Autofac;
using NLog;
using NWN.Core.NWNX;
using Velen.Server.Models;

namespace Velen.Leveling.Services.Experience;

/// <summary>
/// Disables the default xp scale as the configured exp scale is used instead.
/// </summary>
[ServiceBinding(typeof(ExperienceSetupService))]
public class ExperienceSetupService
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public ExperienceSetupService()
    {
        NwModule.Instance.XPScale = 0;
        NwModule.Instance.OnPlayerRespawn += ResolvePlayerRespawn;
        
        ExperienceConfig.Instance().ExperienceScale = Convert.ToInt32(UtilPlugin.GetEnvironmentVariable("EXP_SCALE"));

        Log.Info("ExperienceSetupService initialized");
    }

    private void ResolvePlayerRespawn(ModuleEvents.OnPlayerRespawn onPlayerRespawn)
    {
        if(onPlayerRespawn.Player.LoginCreature == null) return;
        
        using IContainer container = ContainerConfig.Configure();
        
        VelenPlayer player =
            container.Resolve<VelenPlayer>(new NamedParameter("loginObjectId", onPlayerRespawn.Player.LoginCreature));

        int playerXp = player.GetExperiencePoints();
        int xpToLose = player.GetLevel() * 500;
        player.SetExperiencePoints(playerXp - xpToLose);
    }
}