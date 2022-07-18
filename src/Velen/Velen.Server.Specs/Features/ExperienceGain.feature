Feature: ExperienceGain
A player gains experience points when they kill a monster, complete a quest, or perform an action. Players can also gain experience points from DMs.
The number of experience points received from monster kills depreciates with each level and the number of monsters killed that day. Days are measured in in game days, the duration of which is determined by the module.
Once a player is sufficiently high level, kills will award little to no experience points. Experience must be awarded from other sources at that point. Actual experience gained is calculated by: level > 5 ? exp - (exp * 0.(fatigue + level)) :

    @mytag
    Scenario Outline: A new player gains experience points from kills
        Given a player a level of <level>
        And a fatigue level of <fatigue>
        When the player kills a monster worth <absolute> experience points
        Then the player gains <adjusted> experience points

        Examples:
          | level | fatigue | absolute | adjusted |
          | 1     | 0       | 10       | 10       |
          | 1     | 1.33    | 10       | 10       |
          | 2     | 20.22   | 10       | 10       |
          | 3     | 30.34   | 10       | 10       |
          | 4     | 40      | 10       | 10       |
          | 5     | 50      | 10       | 10       |
          | 6     | 60      | 10       | 3        |
          | 7     | 70      | 10       | 2        |
          | 8     | 80      | 10       | 1        |