using Anvil.API;
using Anvil.Services;
using Velen.Core.Models;

namespace Velen.Leveling.Services;

[ServiceBinding(typeof(ILevelingService))]
public class LevelingService : ILevelingService
{
    public bool LevelUpSuccess { private set; get; }

    public void LevelUp(VelenPlayer velenPlayer)
    {
        NwPlayer player = velenPlayer.NwPlayer;
        velenPlayer.Level += 1;
        LevelUpSuccess = true;
    }
}