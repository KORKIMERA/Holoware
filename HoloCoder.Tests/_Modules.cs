using Holoware.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModulesModule.Infrastructure;
using ModulesModule.ViewModels;

namespace Holoware.Tests
{
    [TestClass]
    public class _Modules
    {
        [TestMethod]
        public void load_modules()
        {
            // Setup
            var viewModel = new ModulesViewModel();
            var dependencies = new ModulesDependencies() { Services = new MockModulesServices() };
            viewModel.Initialize(dependencies);

            // Test
            var modules = viewModel.LoadModules();

            // Verify
            Assert.IsTrue(modules != null);
        }
    }
}