using BoDi;
using FluentAssertions;
using Velen.Leveling.Services;
using Velen.Server.Models;
using Velen.Server.Services.Leveling;
using Velen.Server.Specs.Mock;

namespace Velen.Server.Specs.Steps;

/// <summary>
/// Steps that test experience calculation.
/// </summary>
[Binding]
public class ExperienceGainStepDefinitions
{
    private VelenPlayer _player;
    private readonly IObjectContainer _container;

    private int _priorExperience;
    private int _expectedExperience;

    public ExperienceGainStepDefinitions(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void SetUpExperienceGainService()
    {
        IExperienceCalculatorService exp = new FatigueKillExperienceCalculatorService();
        IExperienceValueProvider expProvider = new MockExperienceValueProvider(1);
        ILevelValueProvider levelValueProvider = new MockLevelValueProvider(1);

        _container.RegisterInstanceAs(expProvider);
        _container.RegisterInstanceAs(exp);
        _container.RegisterInstanceAs(levelValueProvider);
        _player = new VelenPlayer(0, _container.Resolve<IExperienceValueProvider>(),
            _container.Resolve<ILevelValueProvider>());
    }

    [Given(@"a player a level of (.*)")]
    public void GivenAPlayerALevelOf(int level)
    {
        _player.SetLevel(level);
    }

    [Given(@"a fatigue level of (.*)")]
    public void GivenAFatigueLevelOf(float fatigue)
    {
        _player.Fatigue = fatigue;
    }

    [When(@"the player kills a monster worth (.*) experience points")]
    public void WhenThePlayerKillsAMonsterWorthExperiencePoints(int expValue)
    {
        int experiencePoints = _container.Resolve<IExperienceValueProvider>().GetExperiencePoints(_player);
        _priorExperience = experiencePoints;

        _player.SetExperiencePoints(experiencePoints +
                                    _container.Resolve<IExperienceCalculatorService>()
                                        .CalculateExperience(_player, expValue));
    }

    [Then(@"the player gains (.*) experience points")]
    public void ThenThePlayerGainsExperiencePoints(int expValue)
    {
        _expectedExperience = _priorExperience + expValue;
        _container.Resolve<IExperienceValueProvider>().GetExperiencePoints(_player).Should().Be(_expectedExperience);
    }
}