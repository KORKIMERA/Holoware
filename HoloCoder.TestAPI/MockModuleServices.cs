using ModuleModule.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleModule.Entities;

namespace HoloCoder.TestAPI
{
    public class MockModuleServices : IModuleServices
    {
        public Module LoadModule()
        {
            return new Module()
            {
                Id = "Module_1"
            };
        }
    }
}
