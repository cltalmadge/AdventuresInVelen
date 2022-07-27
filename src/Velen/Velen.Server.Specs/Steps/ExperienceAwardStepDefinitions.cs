using BoDi;
using FluentAssertions;
using Velen.Leveling.Services.Experience;
using Velen.Server.Models;
using Velen.Server.Services.Fatigue;
using Velen.Server.Services.Leveling;
using Velen.Server.Specs.Mock;

namespace Velen.Server.Specs.Steps;

[Binding]
public class ExperienceAwardStepDefinitions
{
    private IObjectContainer _container;
    private VelenPlayer _player;
    private int _expBeforeKill;
    private int _expAfterKill;
    
    public ExperienceAwardStepDefinitions(IObjectContainer container)
    {
        _container = container;
    }
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        IExperienceCalculatorService exp = new FatigueKillExperienceCalculatorService();
        IExperienceValueProvider expProvider = new MockExperienceValueProvider(1);
        ILevelValueProvider levelValueProvider = new MockLevelValueProvider(1);
        IFatigueProvider fatigueProvider = new MockFatigueProvider();

        _container.RegisterInstanceAs(expProvider);
        _container.RegisterInstanceAs(exp);
        _container.RegisterInstanceAs(levelValueProvider);
        _container.RegisterInstanceAs(fatigueProvider);
        
        _player = new VelenPlayer(0, _container.Resolve<IExperienceValueProvider>(),
            _container.Resolve<ILevelValueProvider>(), _container.Resolve<IFatigueProvider>());
    }

    [Given(@"a player with a level of (.*)")]
    public void GivenAPlayerWithALevelOf(int level)
    {
        _player.SetLevel(level);
    }

    [Given(@"an overall fatigue level of (.*)")]
    public void GivenAnOverallFatigueLevelOf(int fatigue)
    {
        _player.Fatigue = fatigue;
    }

    [When(@"the player kills a monster with a challenge rating of (.*)")]
    public void WhenThePlayerKillsAMonsterWithAChallengeRatingOf(int challengeRating)
    {
        _expBeforeKill = _player.GetExperiencePoints();
        int xp = _container.Resolve<IExperienceCalculatorService>().CalculateExperience(_player, _player.GetLevel(), challengeRating);
        _expAfterKill = _expBeforeKill + xp;
        _player.SetExperiencePoints(_expAfterKill);
    }

    [Then(@"the player should be awarded (.*) experience")]
    public void ThenThePlayerShouldBeAwardedExperience(decimal expectedExperience)
    {
        (_expAfterKill - _expBeforeKill).Should().Be((int)expectedExperience);
    }
}