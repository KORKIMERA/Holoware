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
        }
    }
}
