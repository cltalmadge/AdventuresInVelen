using Velen.Server.Models;
using Velen.Server.Services.Leveling;

namespace Velen.Server.Specs.Mock;

public class MockExperienceValueProvider : IExperienceValueProvider
{
    private int ExperienceValue { get; set; }

    public MockExperienceValueProvider(int experienceValue)
    {
        ExperienceValue = experienceValue;
    }

    public int GetExperiencePoints(VelenPlayer player)
    {
        return ExperienceValue;
    }

    public void SetExperiencePoints(VelenPlayer player, int xp)
    {
        ExperienceValue = xp;
    }
}