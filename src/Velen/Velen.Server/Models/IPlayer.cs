namespace Velen.Server.Models;

public interface IPlayer : IVelenObject
{
    float Fatigue { get; set; }

    /// <summary>
    /// Gets the player's level depending on the ILevelValueProvider provided to the class.
    /// </summary>
    /// <returns></returns>
    int GetLevel();

    /// <summary>
    /// Sets the level of the player using a ILevelValueProvider that was provided during construction.
    /// </summary>
    /// <param name="level">an integer between 1 and 30, inclusive. Values above 30 will default to 30. Values below 1 will default to 1.</param>
    void SetLevel(int level);

    /// <summary>
    /// Sets the experience of the player using a IExperienceValueProvider that was provided during construction.
    /// </summary>
    /// <param name="xp">the number to set experience to.</param>
    void SetExperiencePoints(int xp);

    /// <summary>
    /// Fetches the total experience points of the player using a IExperienceValueProvider that was provided during construction. 
    /// </summary>
    /// <returns>the experience point value from the experience value provider.</returns>
    int GetExperiencePoints();
}