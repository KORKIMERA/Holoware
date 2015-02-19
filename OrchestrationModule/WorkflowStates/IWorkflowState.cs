using BaseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestrationModule.ApplicationStates
{
    public interface IWorkflowState : IModule
    {
        void Execute();
    }
}
