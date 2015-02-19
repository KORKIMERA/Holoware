using BaseModule;
using ModuleModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleModule.Infrastructure
{
    public interface IModuleServices : IModuleDelegate
    {
        Module LoadModule();
    }
}
