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
            SetUp2PlayerPongGame();
        }

        [When("two players join")]
        public void WhenTwoPlayersJoin()
        {
            Game.Join(new Player());
            Game.Join(new Player());
        }

        [Then("the game starts")]
        public void TheGameStarts()
        {
            Assert.That(Game.HasStarted);
        }
    }
}

