using Velen.Server.Models;

namespace Velen.Server.Services;

public interface IExperienceCalculatorService
{
    public int CalculateExperience(VelenPlayer player, int xpValue);
}