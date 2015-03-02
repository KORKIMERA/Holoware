using Bizmonger.Patterns;
using MessageModule;
using System.Configuration;
using System.Windows.Controls;
using System;
using ArchitectureModule.Infrastructure;
using System.Windows.Input;
using ArchitectureModule.ViewModels;
using System.Windows.Media;
using System.Collections.Specialized;

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
            MessageBus.Instance.Publish(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
        }
    }
}
