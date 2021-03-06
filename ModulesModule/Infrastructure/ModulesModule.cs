﻿using ArchitectureModule.Commands;
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
            _subscription.Subscribe(Global.Messages.REQUEST_MODULES_VIEW, obj =>
                {
                    UXServices.Instance.LoadView(typeof(ModulesView), RegionId.CONTENT);
                });
        }
        private void InitializeViews()
        {
            UXServices.Instance.Register(typeof(ModulesView));
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
