using Anvil.Services;
using Velen.Core.Models;

namespace Velen.Leveling.Services;


public interface ILevelingService
{
    void LevelUp(VelenPlayer velenPlayer);
    bool LevelUpSuccess { get; }
}