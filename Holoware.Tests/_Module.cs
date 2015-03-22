using Bizmonger.Patterns;



using Holoware.TestAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleModule.Infrastructure;
using ModuleModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Holoware.Tests
{
    [TestClass]
    public class _Module
    {
        #region Testware
        [TestCleanup]
        public void Cleanup()
        {
            ServiceLocator.Instance.Clear();
        }
        #endregion
    }
}
