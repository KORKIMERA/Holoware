using ModuleModule.Entities;
using System.Collections.Generic;

namespace ArchitectureModule.Entities
{
    public class Layer
    {
        public string Id { get; set; }
        public IEnumerable<Module> Modules { get; set; }
    }
}