using HoloCoder.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HoloCoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        List<UIElement> _elements = new List<UIElement>();
        IEnumerator<UIElement> _enumerator = null;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyUp += new KeyEventHandler(On_PreviewKeyUp);

            _elements.Add(new Architecture());
            _elements.Add(new Modules());
            _elements.Add(new Module());
            _elements.Add(new Editor());

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