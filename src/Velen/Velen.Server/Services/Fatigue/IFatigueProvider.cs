using Velen.Server.Models;

namespace Velen.Server.Services.Fatigue;

public interface IFatigueProvider
{
    public void SetFatigue(int amount);
    public int GetFatigue(VelenPlayer player);
}