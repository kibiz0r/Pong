using System;

using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Pong.Test
{
    [Binding]
    public class GameStartSteps : StepHelper
    {
        [Given("I have a game of Pong")]
        public void IHaveAGameOfPong()
        {
            Game = Create2PlayerPongGame();
        }

        [When("two players join")]
        public void WhenTwoPlayersJoin()
        {
            Game.Join(Game.PlayerSlots[0]);
            Game.Join(Game.PlayerSlots[1]);
        }

        [Then("the game starts")]
        public void TheGameStarts()
        {
            Assert.That(Game.HasStarted);
        }
    }
}

