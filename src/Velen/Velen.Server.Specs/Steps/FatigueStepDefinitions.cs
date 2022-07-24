using BoDi;
using Velen.Leveling.Services.Fatigue;
using Velen.Server.Services.Fatigue;

namespace Velen.Server.Specs.Steps;

[Binding]
public class FatigueStepDefinitions
{
    private readonly IObjectContainer _container;


    public FatigueStepDefinitions(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void SetUpDependencies()
    {
        IFatigueProvider fatigueProvider = new FatigueProvider();
        _container.RegisterInstanceAs(fatigueProvider);
    }
    
    [Given(@"a number of monsters (.*)")]
    public void GivenANumberOfMonsters(string monsters)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the player kill the monsters")]
    public void WhenThePlayerKillTheMonsters()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"their fatigue should be (.*)")]
    public void ThenTheirFatigueShouldBe(string fatigue)
    {
        ScenarioContext.StepIsPending();
    }
}