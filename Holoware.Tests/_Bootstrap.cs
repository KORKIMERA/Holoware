using Bizmonger.Patterns;
using MessageModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoloCoder.Tests
{
    [TestClass]
    public class _Bootstrap
    {
        [TestMethod]
        public void bootstrap()
        {
            ModuleLoader.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);
        }
    }
}
