using System;
using ModulesModule.Entities;
using ModulesModule.Infrastructure;
using ModuleModule.Entities;

namespace Holoware.TestAPI
{
    public class MockModulesServices : IModulesServices
    {
        public Modules LoadModules()
        {
            return new Modules()
            {
                new Module() { Id = "Module_1" },
                new Module() { Id = "Module_2" },
                new Module() { Id = "Module_3" },
            };
        }
    }
}