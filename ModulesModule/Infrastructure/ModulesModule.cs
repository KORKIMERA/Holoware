using BaseModule;
using Bizmonger.Patterns;
using MessageModule;
using ModulesModule.UI.Views;
using System;
using UXModule;

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
