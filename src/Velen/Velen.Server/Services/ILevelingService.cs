namespace Velen.Server.Services;


public interface ILevelingService : ILevelUpService
{
    bool LevelUpSuccess { get; }
}