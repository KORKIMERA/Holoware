using ArchitectureModule.Entities;
using ArchitectureModule.Infrastructure;

namespace ArchitectureModule.ViewModels
{
    public class LoadArchitectureViewModel
    {
        #region Members
        IArchitectureServices _services = null;
        #endregion

        public void Initialize(ArchitectureDependencies dependencies)
        {
            _services = dependencies.Services;
        }

        public Architecture LoadArchitecture()
        {
            return _services.LoadArchitecture();
        }
    }
}
