using ArchitectureModule.UI.Views;
using BaseModule;
using Bizmonger.Patterns;
using Bizmonger.UILogic;
using NotificationModule.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureModule : IModule
    {
        Subscription _subscription = new Subscription();

        public ArchitectureModule()
        {
            _subscription.Subscribe(UXMessage.REQUEST_CONFIGURE_ARCHITECTURE, (obj) =>
                {
                    ViewLocator.Instance.Load(typeof(CreateArchitectureView));
                });
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
