namespace NBench.VisualStudio.TestAdapter.Tests.Unit.NBenchTestDiscoverer.NBenchTestDiscoverer
{
    using JustBehave;


    using NBench.VisualStudio.TestAdapter;
    using NBench.VisualStudio.TestAdapter.Helpers;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;

    using Xunit;

    public class WhenTheNBenchFunctionalityWrapperIsNotNull : XBehaviourTest<NBenchTestDiscoverer>
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
            this.functionalitywrapper = this.Fixture.Create<INBenchFunctionalityWrapper>();
        }

        protected override void When()
        {
        }

        [Fact]
        public void TheNBenchTestDiscovererIsNotNull()
        {
            Assert.NotNull(this.SystemUnderTest);
        }
    }
}