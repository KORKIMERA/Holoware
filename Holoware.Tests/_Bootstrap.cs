using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bizmonger.Patterns;
using NotificationModule.Messaging;
using OrchestrationModule.ApplicationStates;
using ArchitectureModule.Infrastructure;

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
