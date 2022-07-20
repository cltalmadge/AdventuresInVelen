using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

/// <summary>
/// Allows developers to get the current level of a player depending on the context they are programming in.
/// </summary>
public interface ILevelValueProvider
{
    /// <summary>
    /// Gets the level value of the player based on the implementation.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public int GetLevel(VelenPlayer player);

    /// <summary>
    /// Sets the level value of the player based on the implementation.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="level"></param>
    public void SetLevel(VelenPlayer player, int level);
}