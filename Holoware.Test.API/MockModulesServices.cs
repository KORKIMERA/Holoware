using System;
using ModulesModule.Infrastructure;
using ModuleModule.Entities;
using System.Collections.Generic;

namespace Holoware.TestAPI
{
    public class MockModulesServices : IModulesServices
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> LoadModules()
        {
            return new List<Module>()
            {
                new Module() { Id = "Module_1" },
                new Module() { Id = "Module_2" },
                new Module() { Id = "Module_3" },
            };
        }
    }
}