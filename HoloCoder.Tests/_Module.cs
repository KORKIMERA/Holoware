using ClassModule.Infrastructure;
using ClassModule.ViewModels;
using HoloCoder.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleModule.Infrastructure;
using ModuleModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloCoder.Tests
{
    [TestClass]
    public class _Module
    {
        [TestMethod]
        public void load_module()
        {
            // Setup
            var viewModel = new ModuleViewModel();
            var dependencies = new ModuleDependencies() { Services = new MockModuleServices() };
            viewModel.Initialize(dependencies);

            // Test
            var module = viewModel.LoadModule();

            // Verify
            Assert.IsTrue(module != null);
        }
    }
}
