using Anvil.Services;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services;

[ServiceBinding(typeof(ILevelValueProvider))]
public class LevelProvider : ILevelValueProvider
{
    public int GetLevel(VelenPlayer velenPlayer) => NWScript.GetHitDice(velenPlayer.LoginObjectId);
    public void SetLevel(VelenPlayer player, int level)
    {
        
    }
}