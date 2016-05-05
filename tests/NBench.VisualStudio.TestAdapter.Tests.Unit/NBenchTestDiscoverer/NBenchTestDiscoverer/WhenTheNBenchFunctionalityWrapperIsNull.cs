namespace NBench.VisualStudio.TestAdapter.Tests.Unit.NBenchTestDiscoverer.NBenchTestDiscoverer
{
    using JustBehave;
    using System;
    using NBench.VisualStudio.TestAdapter;
    using NBench.VisualStudio.TestAdapter.Helpers;
using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;
using Xunit;

    public class WhenTheNBenchFunctionalityWrapperIsNull: XBehaviourTest<NBenchTestDiscoverer>
    {
        private INBenchFunctionalityWrapper functionalitywrapper;
        protected override NBenchTestDiscoverer CreateSystemUnderTest()
        {
            return new NBenchTestDiscoverer(this.functionalitywrapper);
        }
        protected override void CustomizeAutoFixture(IFixture fixture)
        {
            fixture.Customize(new AutoNSubstituteCustomization());
        }
        
        protected override void Given()
        {
            this.RecordAnyExceptionsThrown();
            this.functionalitywrapper = null;
        }

        protected override void When()
        {
        }

        [Fact]
        public void AnArgumentNullExceptionShouldBeThrown()
        {
            Assert.IsType<ArgumentNullException>(this.ThrownException);
        }

        [Fact]
        public void TheMessageInTheExceptionDetailsTheFactThatTheFunctionalityWrapperCannotBeNull()
        {
            Assert.Equal("The NBench functionality wrapper you have passed in is null. The NBench functionality wrapper must not be null.\r\nParameter name: functinalityWRapper", this.ThrownException.Message);
        }
    }
}