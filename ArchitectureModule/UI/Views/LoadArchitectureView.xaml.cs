using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ArchitectureModule.UI.Views
{
    /// <summary>
    /// Interaction logic for LoadArchitectureView.xaml
    /// </summary>
    public partial class LoadArchitectureView : UserControl
    {
        #region Members
        List<UIElement> _elements = new List<UIElement>();
        IEnumerator<UIElement> _enumerator = null;
        #endregion

        public LoadArchitectureView()
        {
            InitializeComponent();

            this.PreviewKeyUp += new KeyEventHandler(On_PreviewKeyUp);

            _elements.Add(new ArchitectureModule.UI.Views.ArchitectureView());
            _elements.Add(new ModulesModule.UI.Views.ConfigureModulesView());
            _elements.Add(new ModuleModule.UI.Views.Module());
            _elements.Add(new ClassModule.UI.Views.Editor());

            _enumerator = _elements.GetEnumerator();
            _enumerator.MoveNext();

            ContentRegion.Content = _enumerator.Current;
        }

        /// <summary>
        /// http://stackoverflow.com/questions/741956/pan-zoom-image
        /// </summary>
        private void On_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (!(MyGrid.RenderTransform is ScaleTransform))
            {
                MyGrid.RenderTransform = new ScaleTransform();
            }

            if (e.Key == Key.Down)
            {
                Update(zoom: -.1);
            }
            else if (e.Key == Key.Up)
            {
                Update(zoom: .1);
            }
        }

        private void Update(double zoom)
        {
            var scaleTransform = (ScaleTransform)MyGrid.RenderTransform;
            scaleTransform.ScaleX += zoom;
            scaleTransform.ScaleY += zoom;
        }

        private void ContentRegion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _enumerator.MoveNext();
            ContentRegion.Content = _enumerator.Current;
        }
    }
}
