using BaseModule;
using OrchestrationModule.Infrastructure;
using System.Collections.Generic;

namespace HoloCoder
{
    public class ModuleLoader
    {
        public static IEnumerable<IModule> LoadModules()
        {
            var modules = new List<IModule>();
            modules.Add(new ArchitectureModule.Infrastructure.ArchitectureModule());
            modules.Add(new WorkflowOrchestrationModule());

            return modules;
        }
    }
}
