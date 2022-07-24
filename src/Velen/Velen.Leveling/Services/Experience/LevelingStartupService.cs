using Anvil.Services;
using NLog;

namespace Velen.Leveling.Services.Experience;

[ServiceBinding(typeof(LevelingStartupService))]
public class LevelingStartupService
{
    private static Logger Log = LogManager.GetCurrentClassLogger();

    public LevelingStartupService()
    {
        Log.Info("Configured all dependencies for Velen.Leveling");
    }
}