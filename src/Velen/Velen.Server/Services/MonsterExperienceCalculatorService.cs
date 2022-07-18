using Anvil.Services;
using Velen.Server.Models;

namespace Velen.Server.Services;

[ServiceBinding(typeof(IExperienceCalculatorService))]
public class MonsterExperienceCalculatorService : IExperienceCalculatorService
{
    public int CalculateExperience(VelenPlayer player, int xpValue)
    {
        int fatigueAdjustedValue = (int)(xpValue - xpValue * (player.GetLevel() + player.Fatigue) / 100);
        return player.GetLevel() <= 5 ? xpValue : fatigueAdjustedValue;
    }
}