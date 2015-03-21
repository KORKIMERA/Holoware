using Bizmonger.Patterns;
using MessageModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            var dependenciesModule = new DependenciesModule.Infrastructure.DependenciesModule();
            dependenciesModule.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);
        }
    }
}
