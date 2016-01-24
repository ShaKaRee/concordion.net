﻿using Concordion.NET.Integration;
using Concordion.Spec.Support;

namespace Concordion.Spec.Concordion.Command.AssertEquals
{
    [ConcordionTest]
    public class AssertEqualsTest
    {
        public bool GreetingsProcessed(string fragment)
        {
            return new TestRig()
                .WithFixture(this)
                .ProcessFragment(fragment)
                .IsSuccess;
        }

        public string GetGreeting()
        {
            return new Greeter().GetMessage();
        }
    }

    public class Greeter
    {
        public static string greeting = "Hello World!";

        public string GetMessage()
        {
            return greeting;
        }
    }
}
