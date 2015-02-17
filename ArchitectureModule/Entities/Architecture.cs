using ModuleModule.Entities;

namespace ArchitectureModule.Entities
{
    public class Architecture
    {
        public Module Repository { get; set; }
        public Module Model { get; set; }
        public Module Services { get; set; }
        public Module UserInterface { get; set; }
    }
}
