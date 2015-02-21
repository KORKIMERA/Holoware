using Bizmonger.Patterns;
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

            this.Loaded += (s, e) => { PrepareButton.Focus(); };

            var isIntegrationMode = ConfigurationManager.AppSettings["IsIntegrationMode"] as string;
            MessageBus.Instance.Publish(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
            
        }
    }
}
