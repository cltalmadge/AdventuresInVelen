using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

public interface IExperienceValueProvider
{
    public int GetExperiencePoints(VelenPlayer player);
    void SetExperiencePoints(VelenPlayer player, int xp);
}