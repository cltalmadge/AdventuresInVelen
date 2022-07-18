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

    public void SetExperiencePoints(int xp)
    {
        _expProvider.SetExperiencePoints(this, xp);
    }

    public int GetExperiencePoints()
    {
        return _expProvider.GetExperiencePoints(this);
    }

    public void SetLevel(int level)
    {
        if (level > 30) level = 30;
        if (level < 1) level = 1;

        int expNeeded = level * (level - 1) * 500;

        _expProvider.SetExperiencePoints(this, expNeeded);
        _levelProvider.SetLevel(this, level);
    }
}