namespace Velen.Server.Services.Leveling;


public interface ILevelingService : ILevelUpService
{
    bool LevelUpSuccess { get; }
}