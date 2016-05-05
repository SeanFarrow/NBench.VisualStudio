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
    using NBench.VisualStudio.TestAdapter.Helpers;

    public class WhenTheDiscoveryContextIsNull : XBehaviourTest<NBenchTestDiscoverer>
    {
        private IEnumerable<string> sources;
        private IDiscoveryContext discoverycontext;

        private IMessageLogger messagelogger;
        private ITestCaseDiscoverySink testcasediscoverysink;
        private INBenchFunctionalityWrapper functionalitywrapper;

        protected override void CustomizeAutoFixture(IFixture fixture)
        {
            fixture.Customize(new AutoNSubstituteCustomization());
        }

        protected override NBenchTestDiscoverer CreateSystemUnderTest()
        {
            return new NBenchTestDiscoverer(this.functionalitywrapper);
        }

        protected override void Given()
        {
            this.RecordAnyExceptionsThrown();
            this.functionalitywrapper = this.Fixture.Create<INBenchFunctionalityWrapper>();
            this.sources = this.Fixture.Create<IEnumerable<string>>();
            this.discoverycontext = null;
            this.messagelogger = this.Fixture.Create<IMessageLogger>();
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
            Assert.Equal("The discovery context you have passed in is null. The discovery context must not be null.\r\nParameter name: discoveryContext", this.ThrownException.Message);
        }
    }
}