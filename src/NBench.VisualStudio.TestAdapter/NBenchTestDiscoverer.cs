namespace NBench.VisualStudio.TestAdapter
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using System;
    using System.Collections.Generic;
using System.Linq;

    public class NBenchTestDiscoverer : ITestDiscoverer
    {
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            if (sources == null)
            {
                throw new ArgumentNullException("sources", "The sources collection you have passed in is null. The source collection must be populated.");
            }
            else if (!sources.Any())
            {
                throw new ArgumentException("The sources collection you have passed in is empty. The source collection must be populated.", "sources");
            }
            else if (discoveryContext == null)
            {
                throw new ArgumentNullException("discoveryContext", "The discovery context you have passed in is null. The discovery context must not be null.");
            }
            throw new NotImplementedException();
        }
    }
}