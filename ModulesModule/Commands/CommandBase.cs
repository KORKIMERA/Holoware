using Bizmonger.Patterns;
using ModuleModule.Infrastructure;
using System;

namespace ModulesModule.Infrastructure
{
    public class CommandBase
    {
        #region Members
        protected IModuleServices _services = null;
        protected Subscription _subscription = new Subscription();
        #endregion

        public CommandBase()
        {
            _subscription.SubscribeFirstPublication(Global.Messages.REQUEST_MODULES_DEPENDENCIES_COMPLETED, obj =>
                {
                    var dependencies = obj as ModuleDependencies;
                    _services = dependencies.Services;
                });

            var isIntegrationMode = false;
            MessageBus.Instance.Publish(Global.Messages.REQUEST_MODULES_DEPENDENCIES, isIntegrationMode);
        }

        public virtual void Initialize() { throw new NotImplementedException(); }
    }
}