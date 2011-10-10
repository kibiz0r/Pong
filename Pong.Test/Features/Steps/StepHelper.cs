using System;
using TechTalk.SpecFlow;
namespace Pong.Test
{
    public class StepHelper : TestHelper
    {
        public IPongGame Game
        {
            get { return ScenarioContext.Current["Game"] as IPongGame; }
            set { ScenarioContext.Current["Game"] = value; }
        }
    }
}

