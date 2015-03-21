﻿using ArchitectureModule.Commands;
using ArchitectureModule.UI.Views;
using BaseModule;
using Bizmonger.Patterns;
using MessageModule;
using UXModule;

namespace ArchitectureModule.Infrastructure
{
    public class ArchitectureModule : IModule
    {
        #region Members
        Subscription _subscription = new Subscription();
        #endregion

        public ArchitectureModule()
        {
            InitializeSubscriptions();
            InitializeViews();
            InitializeCommands();
        }

        public void Initialize() { }

        #region Helpers
        private void InitializeSubscriptions()
        {
            _subscription.Subscribe(UXMessage.REQUEST_CONFIGURE_ARCHITECTURE, obj =>
                {
                    UXServices.Instance.LoadView(typeof(ConfigureArchitectureView), RegionId.MAIN);
                });
        }
        private void InitializeViews()
        {
            UXServices.Instance.Register(typeof(ArchitectureView));
            UXServices.Instance.Register(typeof(ConfigureArchitectureView));
            UXServices.Instance.Register(typeof(LoadArchitectureView));
        }

        private void InitializeCommands()
        {
            var addLayerCommand = new AddLayerCommand();
            addLayerCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(AddLayerCommand), addLayerCommand);

            var viewLayerCommand = new ViewLayerCommand();
            viewLayerCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(ViewLayerCommand), addLayerCommand);

            var removeLayerCommand = new RemoveLayerCommand();
            removeLayerCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(RemoveLayerCommand), addLayerCommand);
        }
        #endregion
    }
}
