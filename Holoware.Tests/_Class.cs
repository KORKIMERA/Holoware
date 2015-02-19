using ClassModule.Infrastructure;
using ClassModule.ViewModels;
using Holoware.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holoware.Tests
{
    [TestClass]
    public class _Class
    {
        [TestMethod]
        public void load_class()
        {
            // Setup
            var viewModel = new ClassViewModel();
            var dependencies = new ClassDependencies() { Services = new MockClassServices() };
            viewModel.Initialize(dependencies);

            // Test
            var @class = viewModel.LoadClass();

            // Verify
            Assert.IsTrue(@class != null);
        }
    }
}
