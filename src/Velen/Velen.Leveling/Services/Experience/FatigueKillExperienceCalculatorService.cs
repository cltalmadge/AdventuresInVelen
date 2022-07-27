using Anvil.Services;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling.Services.Experience;

[ServiceBinding(typeof(IExperienceCalculatorService))]
public sealed class FatigueKillExperienceCalculatorService : IExperienceCalculatorService
{
    public int CalculateExperience(VelenPlayer player, int partyLevel, int challengeRating)
    {
        int baseXp = 25 + (int)(5.0 * (challengeRating - partyLevel));
        int fatigueAdjustment = (int)((player.GetLevel() + player.Fatigue) / 10);
        return Math.Clamp(baseXp - fatigueAdjustment, 0, 100);
    }
}