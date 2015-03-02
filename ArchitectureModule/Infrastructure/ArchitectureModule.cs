using ArchitectureModule.UI.Views;
using BaseModule;
using Bizmonger.Patterns;
using MessageModule.Messaging;
using System;
using UIModule;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureModule : IModule
    {
        Subscription _subscription = new Subscription();

        public ArchitectureModule()
        {
            UXServices.Instance.Register(typeof(ArchitectureView));
            UXServices.Instance.Register(typeof(ConfigureArchitectureView));
            UXServices.Instance.Register(typeof(LoadArchitectureView));

            _subscription.Subscribe(UXMessage.REQUEST_CONFIGURE_ARCHITECTURE, (obj) =>
                {
                    UXServices.Instance.LoadView(typeof(Controls.Console), RegionId.MAIN);
                });
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
