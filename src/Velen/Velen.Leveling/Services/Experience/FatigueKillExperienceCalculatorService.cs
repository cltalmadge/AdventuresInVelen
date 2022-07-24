using Anvil.Services;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services.Experience;

[ServiceBinding(typeof(IExperienceCalculatorService))]
public sealed class FatigueKillExperienceCalculatorService : IExperienceCalculatorService
{
    public int CalculateExperience(VelenPlayer player, int xpValue)
    {
        int fatigueAdjustedValue = (int)(xpValue - xpValue * (player.GetLevel() + player.Fatigue) / 100);
        return player.GetLevel() <= 5 ? xpValue : fatigueAdjustedValue;
    }
}