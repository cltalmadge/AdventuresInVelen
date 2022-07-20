using Velen.Server.Services.Leveling;

namespace Velen.Server.Models;

public class VelenPlayer
{
    private readonly IExperienceValueProvider _expProvider;
    private readonly ILevelValueProvider _levelProvider;

    public VelenPlayer(uint loginObjectId, IExperienceValueProvider expProvider, ILevelValueProvider levelProvider)
    {
        _expProvider = expProvider;
        _levelProvider = levelProvider;
        LoginObjectId = loginObjectId;
    }

    public uint LoginObjectId { get; }
    public float Fatigue { get; set; }

    public int GetLevel() => _levelProvider.GetLevel(this);

    /// <summary>
    /// Sets the level of the player using a ILevelValueProvider that was provided during construction.
    /// </summary>
    /// <param name="level">an integer between 1 and 30, inclusive. Values above 30 will default to 30. Values below 1 will default to 1.</param>
    public void SetLevel(int level) => _levelProvider.SetLevel(this, Math.Clamp(level, 1, 30));

    public void SetExperiencePoints(int xp)
    {
        _expProvider.SetExperiencePoints(this, xp);
    }

    public int GetExperiencePoints()
    {
        return _expProvider.GetExperiencePoints(this);
    }
}