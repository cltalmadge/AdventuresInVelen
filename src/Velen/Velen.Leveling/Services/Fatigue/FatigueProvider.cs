using Anvil.API;
using NWN.Core;
using Velen.Server.Models;
using Velen.Server.Services.Fatigue;

namespace Velen.Leveling.Services.Fatigue;

public class FatigueProvider : IFatigueProvider
{
    private const string FatiguePrefix = "Fatigue_";

    public void SetFatigue(VelenPlayer player, float amount) =>
        NWScript.SetCampaignFloat(NwModule.Instance.Name, FatiguePrefix + NWScript.GetName(player.LoginObjectId),
            amount);

    public float GetFatigue(VelenPlayer player) => NWScript.GetCampaignFloat(NwModule.Instance.Name,
        FatiguePrefix + NWScript.GetName(player.LoginObjectId));
}