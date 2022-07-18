Feature: LevelUp
A player levels up and a series of checks are performed before and after levelups occur.

    @mytag
    Scenario Outline: A player levels up
        Given a player with a level of <level>
        When the player levels up
        Then the level up success value is <success>
        And the level should be <nextLevel>

        Examples:
          | level | success | nextLevel |
          | 1     | true       | 2         |
          | 2     | true       | 3         |
          | 3     | true       | 4         |
          | 4     | true       | 5         |
          | 5     | true       | 6         |
          | 6     | true       | 7         |
          | 7     | true       | 8         |
          | 8     | true       | 9         |
          | 9     | true       | 10        |
          | 10    | true       | 11        |
          | 11    | true       | 12        |
          | 12    | true       | 13        |
          | 13    | true       | 14        |
          | 14    | true       | 15        |
          | 15    | true       | 16        |
          | 16    | true       | 17        |
          | 17    | true       | 18        |
          | 18    | true       | 19        |
          | 19    | true       | 20        |
          | 20    | true       | 21        |
          | 21    | true       | 22        |
          | 22    | true       | 23        |
          | 23    | true       | 24        |
          | 24    | true       | 25        |
          | 25    | true       | 26        |
          | 26    | true       | 27        |
          | 27    | true       | 28        |
          | 28    | true       | 29        |
          | 29    | true       | 30        |