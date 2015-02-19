using System;
using Bizmonger.Patterns;
using NotificationModule.Messaging;

namespace OrchestrationModule.ApplicationStates
{
    public class StartWorkflowState : IWorkflowState
    {
        Subscription _subscription = new Subscription();

        public StartWorkflowState()
        {
            _subscription.Subscribe(KernelMessage.REQUEST_BOOTSTRAP, (obj) => Execute());
        }

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