using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
namespace Pong.Test
{
    public class StepHelper : TestHelper
    {
        public IPongGame Game
        {
            get { return ScenarioContext.Current["Game"] as IPongGame; }
            set { ScenarioContext.Current["Game"] = value; }
        }

        public Point ParsePoint(string str)
        {
            var xy = Regex.Split(str, @",\s*");
            return new Point(float.Parse(xy[0]), float.Parse(xy[1]));
        }
    }
}

