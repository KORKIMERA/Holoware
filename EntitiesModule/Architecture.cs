using System.Collections.Generic;

namespace ArchitectureModule.Entities
{
    public class Architecture
    {
        public IEnumerable<Layer> Layers { get; set; }
    }
}