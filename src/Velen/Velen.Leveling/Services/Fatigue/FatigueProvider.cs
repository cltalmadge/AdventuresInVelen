using Velen.Server.Models;
using Velen.Server.Services.Fatigue;

namespace Velen.Leveling.Services.Fatigue;

public class FatigueProvider : IFatigueProvider
{
    public void SetFatigue(VelenPlayer player, float amount)
    {
    }

    public float GetFatigue(VelenPlayer player)
    {
        return 0;
    }
}