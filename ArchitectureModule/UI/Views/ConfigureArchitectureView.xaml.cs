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

            this.Loaded += (s, e) => { PrepareButton.Focus(); };

            ((INotifyCollectionChanged)ConsoleView.ItemsSource).CollectionChanged += (s, e) =>
                 {
                     if (e.Action == NotifyCollectionChangedAction.Add)
                     {
                         ConsoleView.ScrollIntoView(ConsoleView.Items[ConsoleView.Items.Count - 1]);
                     }
                 };

            var isIntegrationMode = ConfigurationManager.AppSettings["IsIntegrationMode"] as string;
            MessageBus.Instance.Publish(SystemMessage.REQUEST_ARCHITECTURE_DEPENDENCIES, bool.Parse(isIntegrationMode));
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var commandPane = sender as TextBox;
            commandPane.TextChanged -= OnTextChanged;

            var textBox = sender as TextBox;
            var canDecorate = textBox.Text.Contains(Constants.COMMAND_PLACEHOLDER);

            if (canDecorate)
            {
                var startIndex = textBox.Text.IndexOf(Constants.COMMAND_PLACEHOLDER);
                var length = Constants.COMMAND_PLACEHOLDER.Length;

                commandPane.Focus();
                textBox.Select(startIndex, length);
            }

            commandPane.TextChanged += OnTextChanged;
        }

        private void OnCommandLineLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.Focus();
        }
    }
}
