using Bizmonger.Patterns;
using MessageModule;
using System.Windows;
using System.Windows.Controls;
using UXModule;

namespace Holoware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        Subscription _subscription = new Subscription();

        Regions Regions = new Regions();

        public Shell()
        {
            InitializeComponent();

            _subscription.Subscribe(UXMessage.ASSIGN_MAIN_REGION, obj => { FrontRegion.Content = obj as ContentControl; });

            var dependenciesModule = new DependenciesModule.Infrastructure.DependenciesModule();
            dependenciesModule.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);
        }
    }
}