using Bizmonger.Patterns;
using MessageModule;
using System.Configuration;
using System.Windows.Controls;
using System;
using ArchitectureModule.Infrastructure;

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

            CommandPane.TextChanged += OnTextChanged;

            var isIntegrationMode = ConfigurationManager.AppSettings["IsIntegrationMode"] as string;
            MessageBus.Instance.Publish(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
            
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CommandPane.Focus();
            CommandPane.TextChanged -= OnTextChanged;

            var textBox = sender as TextBox;
            var canDecorate = textBox.Text.Contains(Constants.COMMAND_PLACEHOLDER);

            if (canDecorate)
            {
                var startIndex = textBox.Text.IndexOf(Constants.COMMAND_PLACEHOLDER);
                var length = Constants.COMMAND_PLACEHOLDER.Length;
                textBox.Select(startIndex, length);
            }

            CommandPane.TextChanged += OnTextChanged;
        }
    }
}
