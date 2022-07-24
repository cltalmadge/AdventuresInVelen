Feature: Fatigue
Characters who only fight and run around non-stop can get tired over time. This tiredness is measured using Fatigue.
Low fatigue values will barely affect the character's experience received whilst high fatigue values will have minor debuffs and fewer experience points awarded.
High fatigue values can be remediated by resting, eating, and by receiving aid from a druid or cleric.

    @mytag
    Scenario Outline: A player kills a number of monsters
        Given a number of monsters <monsters>
        When the player kill the monsters
        Then their fatigue should be <fatigue>

        Examples:
          | monsters | fatigue |
          | 10       | 1       |
          | 20       | 2       |
          | 30       | 3       |
          | 40       | 4       |
          | 50       | 5       |
          | 100      | 10      |
          | 200      | 20      |