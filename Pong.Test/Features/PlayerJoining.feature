Feature: Player joining

Scenario: Two players join
    Given I have a game of Pong
    When two players join
    Then the game starts