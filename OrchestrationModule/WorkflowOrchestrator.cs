using OrchestrationModule.ApplicationStates;

namespace OrchestrationModule
{
    public class WorkflowOrchestrator
    {
        public void Initialize()
        {
            
        }

        public void Execute(IWorkflowState state)
        {
            state.Execute();
        }
    }
}
