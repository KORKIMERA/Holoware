using BaseModule;
using Bizmonger.Patterns;
using MessageModule;

namespace CommandModule.Infrastructure
{
    public class CommandModule : IModule
    {
        Subscription _subscription = new Subscription();

        public CommandModule()
        {
            _subscription.Subscribe(SystemMessage.REQUEST_BOOTSTRAP, (obj) => { new CommandPreprossor(); ; });
        }
        public void Initialize()
        {
            
        }
    }
}