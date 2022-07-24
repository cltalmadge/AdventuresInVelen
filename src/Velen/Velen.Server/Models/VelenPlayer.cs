using Velen.Server.Services.Fatigue;
using Velen.Server.Services.Leveling;

namespace Velen.Server.Models;

public class VelenPlayer : IPlayer
{
    private readonly IExperienceValueProvider _expProvider;
    private readonly ILevelValueProvider _levelProvider;
    private IFatigueProvider _fatigueProvider;

    public VelenPlayer(uint loginObjectId, IExperienceValueProvider expProvider, ILevelValueProvider levelProvider,
        IFatigueProvider fatigueProvider)
    {
        LoginObjectId = loginObjectId;
        _expProvider = expProvider;
        _levelProvider = levelProvider;
        _fatigueProvider = fatigueProvider;
    }

    public uint LoginObjectId { get; }

    public float Fatigue
    {
        get => _fatigueProvider.GetFatigue(this);
        set => _fatigueProvider.SetFatigue(this, value);
    }

    /// <summary>
    /// Gets the player's level depending on the ILevelValueProvider provided to the class.
    /// </summary>
    /// <returns></returns>
    public int GetLevel() => _levelProvider.GetLevel(this);

    /// <summary>
    /// Sets the level of the player using a ILevelValueProvider that was provided during construction.
    /// </summary>
    /// <param name="level">an integer between 1 and 30, inclusive. Values above 30 will default to 30. Values below 1 will default to 1.</param>
    public void SetLevel(int level) => _levelProvider.SetLevel(this, Math.Clamp(level, 1, 30));

    /// <summary>
    /// Sets the experience of the player using a IExperienceValueProvider that was provided during construction.
    /// </summary>
    /// <param name="xp">the number to set experience to.</param>
    public void SetExperiencePoints(int xp) => _expProvider.SetExperiencePoints(this, xp);

    /// <summary>
    /// Fetches the total experience points of the player using a IExperienceValueProvider that was provided during construction. 
    /// </summary>
    /// <returns>the experience point value from the experience value provider.</returns>
    public int GetExperiencePoints() => _expProvider.GetExperiencePoints(this);
}