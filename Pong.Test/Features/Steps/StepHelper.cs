using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
namespace Pong.Test
{
    public class StepHelper : HighLevelTestHelper
    {
        public override IPongGame Game
        {
            get { return ScenarioContext.Current["Game"] as IPongGame; }
            set { ScenarioContext.Current["Game"] = value; }
        }

        public override RiggedBallInitializer BallInitializer
        {
            get { return ScenarioContext.Current["BallInitializer"] as RiggedBallInitializer; }
            set { ScenarioContext.Current["BallInitializer"] = value; }
        }

        public Point ParsePoint(string str)
        {
            var xy = Regex.Split(str, @",\s*");
            return new Point(float.Parse(xy[0]), float.Parse(xy[1]));
        }
    }
}

