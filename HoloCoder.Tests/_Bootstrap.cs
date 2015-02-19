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
            var architectureServices = new ArchitectureServices();
            var startWorkflow = new StartWorkflowState();
            MessageBus.Instance.Publish(KernelMessage.REQUEST_BOOTSTRAP);
        }
    }
}
