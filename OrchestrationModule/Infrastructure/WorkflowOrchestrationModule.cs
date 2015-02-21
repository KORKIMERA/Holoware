using BaseModule;
using Bizmonger.Patterns;
using MessageModule;
using OrchestrationModule.ApplicationStates;

namespace OrchestrationModule.Infrastructure
{
    public class WorkflowOrchestrationModule : IModule
    {
        Subscription _subscription = new Subscription();

        public WorkflowOrchestrationModule()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_BOOTSTRAP, (obj) => { new StartWorkflowState().Execute(); });
        }

        public void Initialize()
        {
        }
    }
}
