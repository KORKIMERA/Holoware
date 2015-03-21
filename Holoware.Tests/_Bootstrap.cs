using Bizmonger.Patterns;
using Bizmonger.UILogic;
using MessageModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;

namespace HoloCoder.Tests
{
    [TestClass]
    public class _Bootstrap
    {
        #region Testware
        [TestCleanup]
        public void Cleanup()
        {
            ServiceLocator.Instance.Clear();
        }
        #endregion

        [TestMethod]
        public void bootstrap()
        {
            ModuleLoader.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);
        }
    }
}
