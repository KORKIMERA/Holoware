using System.Collections.Generic;
using System.Windows.Controls;

namespace Bizmonger.UILogic
{
    public class ViewLocator : Dictionary<string, UserControl>
    {
        #region Singleton
        static ViewLocator _viewLocator = null;
        public static ViewLocator Instance
        {
            get
            {
                if (_viewLocator == null)
                {
                    _viewLocator = new ViewLocator();
                }

                return _viewLocator;
            }
        }
        #endregion
    }
}