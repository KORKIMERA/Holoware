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
            _subscription.Subscribe(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES, obj =>
                {
                    var isIntegrationMode = (bool)obj;
                    var dependencies = Generate(isIntegrationMode);

                    MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, dependencies);
                });

            _subscription.Subscribe(SystemMessage.REQUEST_BOOTSTRAP, (obj) => { Generate(isIntegrationMode: false); });
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
                    Services = ArchitectureServices.Instance
                };
            }
            else
            {
                return new ArchitectureDependencies()
                {
                    Services = MockArchitectureServices.Instance
                };
            }
        }
    }
}