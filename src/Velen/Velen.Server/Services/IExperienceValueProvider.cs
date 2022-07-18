using Velen.Server.Models;

namespace Velen.Server.Services;

public interface IExperienceValueProvider
{
    public int GetExperiencePoints(VelenPlayer player);
    void SetExperiencePoints(VelenPlayer player, int xp);
}