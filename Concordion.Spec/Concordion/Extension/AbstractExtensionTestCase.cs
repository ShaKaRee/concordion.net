﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concordion.Spec.Support;
using org.concordion.api.extension;

namespace Concordion.Spec.Concordion.Extension
{
    public class AbstractExtensionTestCase
    {
        #region Fields

        protected ConcordionExtension Extension { get; set; }

        protected TestRig TestRig { get; set; }

        protected ProcessingResult ProcessingResult { get; set; }

        public TextWriter LogWriter { get; set; }

        #endregion

        public AbstractExtensionTestCase()
        {
            this.LogWriter = new StringWriter();
        }

        public void processAnything()
        {
            process("<p>anything..</p>");
        }
    
        public void process(string fragment)
        {
            TestRig = new TestRig();
            this.ConfigureTestRig();
            ProcessingResult = TestRig.WithFixture(this)
              .WithExtension(this.Extension)
              .ProcessFragment(fragment);
        }

        protected virtual void ConfigureTestRig()
        {
        }

        public List<string> getEventLog()
        {
            LogWriter.Flush();
            var loggedEvents = LogWriter.ToString().Split(new[] {LogWriter.NewLine}, StringSplitOptions.None);
            var eventLog = loggedEvents.ToList();
            eventLog.Remove("");
            return eventLog;
        }

        public bool isAvailable(string resourcePath) {
            return TestRig.HasCopiedResource(new org.concordion.api.Resource(resourcePath));
        }
    }
}
