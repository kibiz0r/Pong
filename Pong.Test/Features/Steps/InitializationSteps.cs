using System;

using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace Pong.Test
{
    [Binding]
    public class InitializationSteps : StepHelper
    {
        [Given("I have a game of Pong")]
        public void IHaveAGameOfPong()
        {
            IHaveAGameOfPong(null);
        }

        [Given("I have a game of Pong:")]
        public void IHaveAGameOfPong(Table table)
        {
            BallInitializer = new RiggedBallInitializer();
            var game = Create2PlayerPongGame();
            if (table != null)
            {
                if (table.ContainsColumn("Player Slot") || table.ContainsColumn("Spawn Position"))
                {
                    game.PlayerSlots = (from row in table.Rows
                        orderby row["Player Slot"]
                        select new PlayerSlot { SpawnPosition = ParsePoint(row["Spawn Position"]) }).ToArray();
                }
                if (table.ContainsColumn("Width") || table.ContainsColumn("Height"))
                {
                    game.Width = int.Parse(table.Rows[0]["Width"]);
                    game.Height = int.Parse(table.Rows[0]["Height"]);
                }
            }
            Game = game;
        }

        [Given(@"the spawn velocity of the ball is (.*)")]
        public void TheSpawnVelocityOfTheBallIs(string point)
        {
            BallInitializer.SpawnVelocity = ParsePoint(point);
        }

        [Then(@"I should see paddle (\d+) at (.*)")]
        public void IShouldSeePaddleAt(int slotIndex, string point)
        {
            Assert.That(Game.Players[slotIndex].Paddle.Position, Is.EqualTo(ParsePoint(point)));
        }

        [Then(@"I should see a ball at (.*)")]
        public void IShouldSeeABallAt(string point)
        {
            Assert.That(Game.Ball.Position, Is.EqualTo(ParsePoint(point)));
        }

        [Then(@"I should see a ball moving at (.*)")]
        public void IShouldSeeABallMovingAt(string point)
        {
            Assert.That(Game.Ball.Velocity, Is.EqualTo(ParsePoint(point)));
        }
    }
}

