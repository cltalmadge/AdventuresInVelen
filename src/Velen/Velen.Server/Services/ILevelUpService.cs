using Velen.Server.Models;

namespace Velen.Server.Services;

public interface ILevelUpService
{
    public void LevelUp(VelenPlayer velenPlayer);
}