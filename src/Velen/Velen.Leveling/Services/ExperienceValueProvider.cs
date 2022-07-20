using Anvil.Services;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services;

[ServiceBinding(typeof(IExperienceValueProvider))]
public sealed class ExperienceValueProvider : IExperienceValueProvider
{
    public int GetExperiencePoints(VelenPlayer player) => NWScript.GetXP(player.LoginObjectId);
    public void SetExperiencePoints(VelenPlayer player, int xp) => NWScript.SetXP(player.LoginObjectId, xp);
}