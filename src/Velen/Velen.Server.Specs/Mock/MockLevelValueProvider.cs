using Velen.Server.Models;
using Velen.Server.Services;
using Velen.Server.Services.Leveling;

namespace Velen.Server.Specs.Mock;

public class MockLevelValueProvider : ILevelValueProvider
{
    private int _level;

    public MockLevelValueProvider(int level)
    {
        _level = level;
    }

    public int GetLevel(VelenPlayer player)
    {
        return _level;
    }

    public void SetLevel(VelenPlayer player, int level)
    {
        _level = level;
    }
}