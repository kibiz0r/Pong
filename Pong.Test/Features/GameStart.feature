Feature: Game starting

Scenario: The game starts when two players join
    Given I have a game of Pong
    When two players join
    Then the game starts
