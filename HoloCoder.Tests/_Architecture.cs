using ArchitectureModule.Infrastructure;
using ArchitectureModule.ViewModels;
using Holoware.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Holoware.Tests
{
    [TestClass]
    public class _Architecture
    {
        [TestMethod]
        public void load_architecture()
        {
            // Setup
            var viewModel = new LoadArchitectureViewModel();
            var dependencies = new ArchiectureDependencies() { Services = new MockArchitectureServices() };
            viewModel.Initialize(dependencies);

            // Test
            var architecture = viewModel.LoadArchitecture();

            // Verify
            Assert.IsTrue(architecture != null);
        }
    }
}