using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;
using System;

namespace ArchitectureModule.Commands
{
    public class CommandBase
    {
        #region Members
        protected IArchitectureServices _services = null;
        protected Subscription _subscription = new Subscription();
        #endregion

        public CommandBase()
        {
            _subscription.SubscribeFirstPublication(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
                {
                    var dependencies = obj as ArchitectureDependencies;
                    _services = dependencies.Services;
                });

            var isIntegrationMode = false;
            MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES, isIntegrationMode);
        }

        public virtual void Initialize() { throw new NotImplementedException(); }
    }
}