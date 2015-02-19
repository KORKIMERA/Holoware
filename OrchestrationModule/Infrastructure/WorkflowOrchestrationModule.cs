using BaseModule;
using Bizmonger.Patterns;
using NotificationModule.Messaging;
using OrchestrationModule.ApplicationStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
