using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrchestrationModule;
using OrchestrationModule.ApplicationStates;
using Bizmonger.UILogic;

namespace Holoware.Tests
{
    [TestClass]
    public class _WorkflowOrchestrator
    {
        #region Testware
        [TestCleanup]
        public void Cleanup()
        {
            ViewLocator.Instance.Clear();
        }
        #endregion

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