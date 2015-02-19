using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace Bizmonger.UILogic
{
    public class ViewLocator
    {
        #region Members
        Dictionary<Type, UserControl> _dictionary = new Dictionary<Type, UserControl>();
        static ViewLocator _viewLocator = null;
        #endregion

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

        public object this[Type key]
        {
            get
            {
                if (!_dictionary.ContainsKey(key))
                {
                    var usertControl = Activator.CreateInstance(key) as UserControl;
                    Debug.Assert(usertControl != null);

                    _dictionary.Add(key, usertControl);
                }

                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value as UserControl;
            }
        }

        public bool ContainsKey(Type viewType)
        {
            return _dictionary.ContainsKey(viewType);
        }

        public void Load(Type viewType)
        {
            if (viewType == null) { return; }

            RemoveExisting(viewType);

            _dictionary.Add(viewType, Activator.CreateInstance(viewType) as UserControl);
        }

        public void Load(Type type, UserControl view)
        {
            if (view == null) { return; }

            RemoveExisting(view);

            _dictionary.Add(type, view);
        }

        #region Helpers
        private void RemoveExisting(object data)
        {
            bool found = _dictionary.ContainsKey(data.GetType());

            if (found)
            {
                _dictionary.Remove(data.GetType());
            }
        }
        #endregion
    }
}