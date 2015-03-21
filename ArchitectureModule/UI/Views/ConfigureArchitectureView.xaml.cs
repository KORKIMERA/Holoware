using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using MessageModule;
using System.Configuration;
using System.Windows.Controls;

namespace ArchitectureModule.UI.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class ConfigureArchitectureView : UserControl
    {
        public ConfigureArchitectureView()
        {
            InitializeComponent();

            var isIntegrationMode = ConfigurationManager.AppSettings["IsIntegrationMode"] as string;
            MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
        }
    }
}
