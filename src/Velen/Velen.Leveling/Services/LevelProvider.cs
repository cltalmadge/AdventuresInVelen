using Anvil.Services;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services;

[ServiceBinding(typeof(ILevelValueProvider))]
public sealed class LevelProvider : ILevelValueProvider
{
    public int GetLevel(VelenPlayer player) => NWScript.GetHitDice(player.LoginObjectId);
    public void SetLevel(VelenPlayer player, int level)
    {
    }
}