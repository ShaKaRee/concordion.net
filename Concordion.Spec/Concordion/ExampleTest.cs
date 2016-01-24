﻿using Concordion.NET.Integration;
using Concordion.Spec.Support;

namespace Concordion.Spec.Concordion
{
    [ConcordionTest]
    public class ExampleTest
    {
        public string greeting = "Hello World!";

        public string process(string html)
        {
            return new TestRig()
                .WithFixture(this)
                .Process(html)
                .SuccessOrFailureInWords()
                .ToLower();
        }
    }
}
