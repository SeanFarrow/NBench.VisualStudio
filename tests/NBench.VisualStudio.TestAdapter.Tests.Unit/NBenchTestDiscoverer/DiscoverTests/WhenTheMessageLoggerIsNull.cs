namespace NBench.VisualStudio.TestAdapter.Tests.Unit.NBenchTestDiscoverer.DiscoverTests
{
    using System;
    using System.Collections.Generic;

    using JustBehave;

    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

    using NBench.VisualStudio.TestAdapter;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;

    using Xunit;
    using System.Linq;

    public class WhenTheMessageLoggerIsNull : XBehaviourTest<NBenchTestDiscoverer>
    {
        private IEnumerable<string> sources;
        private IDiscoveryContext discoverycontext;

        private IMessageLogger messagelogger;
        private ITestCaseDiscoverySink testcasediscoverysink;

        protected override void CustomizeAutoFixture(IFixture fixture)
        {
            fixture.Customize(new AutoNSubstituteCustomization());
        }

        protected override NBenchTestDiscoverer CreateSystemUnderTest()
        {
            return new NBenchTestDiscoverer();
        }

        protected override void Given()
        {
            this.RecordAnyExceptionsThrown();
            this.sources = this.Fixture.Create<IEnumerable<string>>();
            this.discoverycontext = this.Fixture.Create<IDiscoveryContext>();
            this.messagelogger = null;
            this.testcasediscoverysink = this.Fixture.Create<ITestCaseDiscoverySink>();
        }

        protected override void When()
        {
            this.SystemUnderTest.DiscoverTests(this.sources, this.discoverycontext, this.messagelogger, this.testcasediscoverysink);
        }

        [Fact]
        public void AnArgumentNullExceptionShouldBeThrown()
        {
            Assert.IsType<ArgumentNullException>(this.ThrownException);
        }

        [Fact]
        public void TheMessageInTheExceptionDetailsTheFactThatTheDiscoveryContextCannotBeNull()
        {
            Assert.Equal("The message logger you have passed in is null. The message logger must not be null.\r\nParameter name: messageLogger", this.ThrownException.Message);
        }
    }
}