using Velen.Server.Models;
using Velen.Server.Services.Fatigue;

namespace Velen.Server.Specs.Mock;

public class MockFatigueProvider : IFatigueProvider
{
    private float Fatigue { get; set; }
    public void SetFatigue(VelenPlayer player, float amount) => Fatigue = amount;

    public float GetFatigue(VelenPlayer player) => Fatigue;
}