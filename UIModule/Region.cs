using Bizmonger.UILogic;
using System;
using System.Windows.Controls;

namespace UIModule
{
    public class Region : ContentControl
    {
        #region Members
        UXServices _UXServices = UXServices.Instance;
        ViewLocator _viewLocator = ViewLocator.Instance;
        #endregion

        public void Load(UserControl view)
        {
            Content = view;
        }

        public void Load(Type type, object parameter)
        {
            if (Content != null && Content is Frame)
            {
                var frame = Content as Frame;
                frame.Navigate(type, parameter);
            }
        }
    }
}
