using ArchitectureModule.Infrastructure;
using Bizmonger.Patterns;

namespace ArchitectureModule.Commands
{
    public abstract class CommandBase
    {
        #region Members
        protected IArchitectureServices _services = null;
        protected Subscription _subscription = new Subscription();
        #endregion

        public abstract void Initialize();

        //#region Singleton
        //static CommandBase commandbase = null;
        //public static CommandBase Instance
        //{
        //    get
        //    {
        //        if (commandbase == null)
        //        {
        //            commandbase = new CommandBase();
        //        }

        //        return commandbase;
        //    }
        //}

        //protected CommandBase()
        //{
        //    _subscription.SubscribeFirstPublication(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES_COMPLETED, obj =>
        //        {
        //            var dependencies = obj as ArchitectureDependencies;
        //            _services = dependencies.Services;
        //        });

        //    var isIntegrationMode = false;
        //    MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES, isIntegrationMode);
        //}
        //#endregion
    }
}