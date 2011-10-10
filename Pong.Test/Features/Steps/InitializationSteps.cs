using System;

using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace Pong.Test
{
    [Binding]
    public class InitializationSteps : StepHelper
    {
        [Given("I have a game of Pong:")]
        public void IHaveAGameOfPong(Table table)
        {
            var game = Create2PlayerPongGame();
            game.PlayerSlots = (from row in table.Rows
                orderby row["Player Slot"]
                select new PlayerSlot { SpawnPosition = ParsePoint(row["Spawn Position"]) }).ToArray();
            Game = game;
        }

        [Then(@"I should see paddle (\d+) at (.*)")]
        public void IShouldSeePaddleAt(int slotIndex, string point)
        {
            Assert.That(Game.Players[slotIndex].Paddle.Position, Is.EqualTo(ParsePoint(point)));
        }
    }
}

