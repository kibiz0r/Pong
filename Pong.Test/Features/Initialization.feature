Feature: Game initialization

Scenario: Game spawns paddles
    Given I have a game of Pong:
        | Player Slot | Spawn Position |
        | 0           | 50, 300        |
        | 1           | 750, 300       |
    When two players join
    Then I should see paddle 0 at 50, 300
    And I should see paddle 1 at 750, 300

Scenario: Game spawns ball
    Given I have a game of Pong:
        | Width | Height |
        | 800   | 600    |
    And the spawn velocity of the ball is 10, 20
    When two players join
    Then I should see a ball at 400, 300
    And I should see a ball moving at 10, 20