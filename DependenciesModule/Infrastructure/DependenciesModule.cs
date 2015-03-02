using ArchitectureModule.Infrastructure;
using BaseModule;
using Bizmonger.Patterns;
using Holoware.TestAPI;
using MessageModule;
using System;

namespace DependenciesModule.Infrastructure
{
    public class DependenciesModule : IModule
    {
        #region Members
        Subscription _subscription = new Subscription();
        #endregion

        public DependenciesModule()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES, obj =>
                {
                    var isIntegrationMode = (bool)obj;
                    var dependencies = Generate(isIntegrationMode);

                    MessageBus.Instance.Publish(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, dependencies);
                });
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public static ArchitectureDependencies Generate(bool isIntegrationMode)
        {
            if (isIntegrationMode)
            {
                return new ArchitectureDependencies()
                {
                    Services = new ArchitectureServices()
                };
            }
            else
            {
                return new ArchitectureDependencies()
                {
                    Services = new MockArchitectureServices()
                };
            }
        }
    }
}