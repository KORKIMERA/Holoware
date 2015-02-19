using System;
using System.Collections.Generic;
using ArchitectureModule.Entities;
using ModuleModule.Entities;
using Bizmonger.Patterns;
using NotificationModule.Messaging;
using Bizmonger.UILogic;
using ArchitectureModule.UI.Views;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureServices : IArchitectureServices
    {
        Subscription _subscription = new Subscription();

        public ArchitectureServices()
        {
            _subscription.Subscribe(UXMessage.REQUEST_CONFIGURE_ARCHITECTURE, (obj) =>
                {
                    ViewLocator.Instance.Load(typeof(CreateArchitectureView));
                });
        }

        public void AddModule(Module module)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Entities.Architecture LoadArchitecture()
        {
            return null;
        }

        public IEnumerable<Module> LoadModuleOptions()
        {
            throw new NotImplementedException();
        }

        public void RemoveModule(Module module)
        {
            throw new NotImplementedException();
        }
    }
}