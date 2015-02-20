using Bizmonger.Patterns;
using MessageModule.Messaging;
using System;

namespace OrchestrationModule.ApplicationStates
{
    public class StartWorkflowState : IWorkflowState
    {
        public void Execute()
        {
            MessageBus.Instance.Publish(UXMessage.REQUEST_CONFIGURE_ARCHITECTURE);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}