using Bizmonger.Patterns;
using System;

namespace OrchestrationModule.ApplicationStates
{
    public class StartWorkflowState : IWorkflowState
    {
        public void Execute()
        {
            MessageBus.Instance.Publish(Global.Messages.REQUEST_CONFIGURE_ARCHITECTURE);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}