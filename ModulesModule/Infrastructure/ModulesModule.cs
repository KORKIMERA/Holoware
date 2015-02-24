using BaseModule;
using Bizmonger.Patterns;
using MessageModule.Messaging;
using ModulesModule.UI.Views;
using System;
using UIModule;

namespace ModulesModule.Infrastructure
{
    public class ModulesModule : IModule
    {
        Subscription _subscription = new Subscription();

        public ModulesModule()
        {
            UXServices.Instance.Register(typeof(Modules));

            _subscription.Subscribe(UXMessage.REQUEST_LAYER_MODULES, (obj) =>
                {
                    UXServices.Instance.LoadView(typeof(Modules), RegionId.MAIN);
                });
        }
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
