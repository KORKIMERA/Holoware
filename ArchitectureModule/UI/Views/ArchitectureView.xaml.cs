using Bizmonger.Patterns;
using System.Configuration;
using System.Windows.Controls;

namespace ArchitectureModule.UI.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class ArchitectureView : UserControl
    {
        public ArchitectureView()
        {
            InitializeComponent();

            var isIntegrationMode = ConfigurationManager.AppSettings["IsIntegrationMode"] as string;
            MessageBus.Instance.Publish(Global.Messages.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
        }
    }
}
