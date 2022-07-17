Feature: LevelUp
	A player levels up and a series of checks are performed before and after levelups occur.

@mytag
Scenario: A player levels up
	Given a player with a level of 1
	When the player levels up
	Then the level up success value is true
	And the player level should be 2
