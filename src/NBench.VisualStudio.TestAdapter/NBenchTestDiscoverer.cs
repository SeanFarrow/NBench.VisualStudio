namespace NBench.VisualStudio.TestAdapter
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using System;
    using System.Collections.Generic;

    public class NBenchTestDiscoverer : ITestDiscoverer
    {
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            if (sources == null)
            {
                throw new ArgumentNullException("sources", "The sources collection you have passed in is null. The source collection must be populated.");
            }
            throw new NotImplementedException();
        }
    }
}