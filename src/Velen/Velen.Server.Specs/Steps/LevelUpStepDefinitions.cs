using FluentAssertions;
using Velen.Leveling.Services;
using Velen.Server.Models;
using Velen.Server.Specs.Mock;

namespace Velen.Server.Specs.Steps;

[Binding]
public class LevelUpStepDefinitions
{
    private readonly LevelingService _levelingService = new();
    private VelenPlayer _velenPlayer;

    [BeforeScenario]
    public void CreateLeveler()
    {
        _velenPlayer = new VelenPlayer(0, new MockExperienceValueProvider(0), new MockLevelValueProvider(1));
    }

    [Given(@"a player with a level of (.*)")]
    public void GivenAPlayerWithALevelOf(int level)
    {
        _velenPlayer.SetLevel(level);
    }

    [When(@"the player levels up")]
    public void WhenThePlayerLevelsUp()
    {
       _levelingService.LevelUp(_velenPlayer);
    }

    [Then(@"the level up success value is *(.*)")]
    public void ThenTheLevelUpSuccessValueIsTrue(bool result)
    {
        _levelingService.LevelUpSuccess.Should().Be(result);
    }

    [Then(@"the level should be (.*)")]
    public void ThenTheLevelShouldBe(int level)
    {
        _velenPlayer.GetLevel().Should().Be(level);
    }
}