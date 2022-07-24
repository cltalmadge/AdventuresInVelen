using Velen.Server.Models;
using Velen.Server.Services.Fatigue;

namespace Velen.Leveling.Services.Fatigue;

public class FatigueProvider : IFatigueProvider
{
    public void SetFatigue(int amount)
    {
    }

    public int GetFatigue(VelenPlayer player)
    {
        return 0;
    }
}