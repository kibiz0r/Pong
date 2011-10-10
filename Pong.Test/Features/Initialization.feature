Feature: Game initialization

Scenario: Game spawns paddles
    Given I have a game of Pong:
        | Player Slot | Spawn Position |
        | 0           | 50, 300        |
        | 1           | 750, 300       |
    When two players join
    Then I should see paddle 0 at 50, 300
    And I should see paddle 1 at 750, 300