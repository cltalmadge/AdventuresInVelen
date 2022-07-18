using Anvil.Services;
using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

[ServiceBinding(typeof(ILevelingService))]
public class LevelingService : ILevelingService
{
    public bool LevelUpSuccess { private set; get; }

    public void LevelUp(VelenPlayer velenPlayer)
    {
        LevelUpSuccess = true;
        velenPlayer.SetLevel(velenPlayer.GetLevel() + 1);
    }
}