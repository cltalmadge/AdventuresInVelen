Feature: ExperienceAward
There are different strategies for how a user can earn experience. The following are the different strategies:
The user kills a monster and earns experience. BaseXP  = ( 25.0 + ( 5.0 * ( fMonsterCR - fPartyLevel ) ) ) * fXPMultiplier
The user completes a quest and earns experience.
The user uses a consumable and earns experience.
The user earns experience from roleplaying.

    @mytag
    Scenario Outline: A single user kills a monster and earns experience
        Given a player with a level of <level>
        And an overall fatigue level of <fatigue>
        When the player kills a monster with a challenge rating of <challenge_rating>
        Then the player should be awarded <experience> experience

        Examples:
          | level | fatigue | challenge_rating | experience |
          | 1     | 0       | 1                | 25.0       |
          | 1     | 0       | 3                | 35.0       |
          | 1     | 100     | 3                | 25.0       |
          | 2     | 0       | 1                | 20.0       |
          | 2     | 0       | 3                | 30.0       |
          | 2     | 100     | 3                | 20.0       |
          | 3     | 0       | 1                | 15.0       |
          | 3     | 0       | 3                | 25.0       |
          | 3     | 100     | 3                | 15.0       |
          | 4     | 0       | 1                | 10.0       |
          | 4     | 0       | 3                | 20.0       |
          | 4     | 100     | 3                | 10.0       |