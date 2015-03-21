using Bizmonger.Patterns;
using Bizmonger.UILogic;
using ClassModule.Infrastructure;
using ClassModule.ViewModels;
using Holoware.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Holoware.Tests
{
    [TestClass]
    public class _Class
    {
        #region Testware
        [TestCleanup]
        public void Cleanup()
        {
            ServiceLocator.Instance.Clear();
        }
        #endregion

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
