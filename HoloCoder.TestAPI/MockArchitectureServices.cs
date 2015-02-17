using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;
using ModuleModule.Entities;

namespace HoloCoder.TestAPI
{
    public class MockArchitectureServices : IArchitectureServices
    {
        public Architecture LoadArchitecture()
        {
            return new Architecture()
            {
                 UserInterface = new Module(),
                 Services = new Module(),
                 Model = new Module(),
                 Repository = new Module()
            };
        }
    }
}
