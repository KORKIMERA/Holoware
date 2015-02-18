using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrchestrationModule;
using OrchestrationModule.ApplicationStates;

namespace HoloCoder.Tests
{
    [TestClass]
    public class _WorkflowOrchestrator
    {
        [TestMethod]
        public void initialize_workflow()
        {
            var orchestrator = new WorkflowOrchestrator();
            orchestrator.Initialize();

            var initialState = new StartWorkflowState();
            orchestrator.Execute(initialState);
        }
    }
}