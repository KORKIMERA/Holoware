using ArchitectureModule.Commands;
using BaseModule;
using Bizmonger.Patterns;
using MessageModule;
using ModulesModule.Commands;
using ModulesModule.UI.Views;
using System;
using UXModule;

namespace ModulesModule.Infrastructure
{
    public class ModulesModule : IModule
    {
        #region Members
        Subscription _subscription = new Subscription();
        #endregion

        public ModulesModule()
        {
            InitializeSubscriptions();
            InitializeViews();
            InitializeCommands();
        }

        public void Initialize() { }

        #region Helpers
        private void InitializeSubscriptions()
        {
            _subscription.Subscribe(UXMessage.REQUEST_LAYER_MODULES, obj =>
                {
                    UXServices.Instance.LoadView(typeof(ConfigureModulesView), RegionId.MAIN);
                });
        }
        private void InitializeViews()
        {
            UXServices.Instance.Register(typeof(ConfigureModulesView));
        }

        private void InitializeCommands()
        {
            var addModuleCommand = new AddModuleCommand();
            addModuleCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(AddModuleCommand), addModuleCommand);

            var viewModuleCommand = new ViewModuleCommand();
            viewModuleCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(ViewModuleCommand), viewModuleCommand);

            var removeModuleCommand = new RemoveModuleCommand();
            removeModuleCommand.Initialize();
            ServiceLocator.Instance.Load(typeof(RemoveModuleCommand), removeModuleCommand);
        }
        #endregion
    }
}
