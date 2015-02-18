using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchestrationModule.ApplicationStates;

namespace OrchestrationModule
{
    public class WorkflowOrchestrator
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Execute(IWorkflowState state)
        {
            state.Execute();
        }
    }
}
