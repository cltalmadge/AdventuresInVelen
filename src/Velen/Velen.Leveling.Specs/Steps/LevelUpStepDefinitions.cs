using BoDi;
using FluentAssertions;
using Velen.Core.Models;
using Velen.Leveling.Services;

namespace Velen.Leveling.Specs.Steps;

[Binding]
public class LevelUpStepDefinitions
{
    private readonly VelenPlayer _velenPlayer = new();
    private IObjectContainer _container;


    public LevelUpStepDefinitions(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void CreateLeveler()
    {
        ILevelingService leveler = new LevelingService();

        _container.RegisterInstanceAs(leveler);
    }

    [Given(@"a player with a level of (.*)")]
    public void GivenAPlayerWithALevelOf(int level)
    {
        _velenPlayer.Level = level;
    }

    [When(@"the player levels up")]
    public void WhenThePlayerLevelsUp()
    {
        _container.Resolve<ILevelingService>().LevelUp(_velenPlayer);
    }

    [Then(@"the level up success value is *(.*)")]
    public void ThenTheLevelUpSuccessValueIsTrue(bool result)
    {
        _container.Resolve<ILevelingService>().LevelUpSuccess.Should().Be(result);
    }

    [Then(@"the player level should be (.*)")]
    public void ThenThePlayerLevelShouldBe(int level)
    {
        _velenPlayer.Level.Should().Be(level);
    }
}