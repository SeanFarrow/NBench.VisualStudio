namespace NBench.VisualStudio.TestAdapter.Tests.Unit.NBenchTestDiscoverer.DiscoverTests
{
    using System;
    using System.Collections.Generic;

    using JustBehave;

    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

    using NBench.VisualStudio.TestAdapter;
    using NBench.VisualStudio.TestAdapter.Helpers;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;

    using Xunit;

    public class WhenTheSourcesCollectionIsNull: XBehaviourTest<NBenchTestDiscoverer>
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
            this.sources = null;
            this.discoverycontext = this.Fixture.Create<IDiscoveryContext>();
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
        public void TheMessageInTheExceptionDetailsTheFactThatTheSourcesCannotBeNull()
        {
            Assert.Equal("The sources collection you have passed in is null. The source collection must be populated.\r\nParameter name: sources", this.ThrownException.Message);
        }
    }
}