using Velen.Server.Models;

namespace Velen.Server.Services.Leveling;

/// <summary>
/// Defines the actions of an object that should set and retrieve experience values based on the environment (file system, nwn, web).
/// </summary>
public interface IExperienceValueProvider
{
    /// <summary>
    /// Gets the total experience that a player has.
    /// </summary>
    /// <param name="player">the player to get the experience of.</param>
    /// <returns>the experience value of the player.</returns>
    public int GetExperiencePoints(VelenPlayer player);
    
    /// <summary>
    /// Sets the total experience that a player has.
    /// </summary>
    /// <param name="player">the player to set the experience of.</param>
    /// <param name="xp">the amount to set the player's experience to.</param>
    void SetExperiencePoints(VelenPlayer player, int xp);
}