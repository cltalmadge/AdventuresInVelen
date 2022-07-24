using Velen.Server.Models;

namespace Velen.Server.Services.Fatigue;

public interface IFatigueProvider
{
    public void SetFatigue(VelenPlayer player, float amount);
    public float GetFatigue(VelenPlayer player);
}