Feature: Motion

Scenario: Ball moves
    Given I have a running game of Pong:
        | Width | Height |
        | 800   | 600    |
    And the ball is at 400, 300
    And the velocity of the ball is 20, 10
    When I wait 1 second
    Then I should see a ball at 420, 310