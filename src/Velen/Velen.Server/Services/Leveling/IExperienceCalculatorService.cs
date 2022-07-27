using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

public interface IExperienceCalculatorService
{
    public int CalculateExperience(VelenPlayer player, int partyLevel, int challengeRating);
}