using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

public interface ILevelUpService
{
    public void LevelUp(VelenPlayer velenPlayer);
}