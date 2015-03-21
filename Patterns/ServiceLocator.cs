using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bizmonger.Patterns
{
    public class ServiceLocator
    {
        #region Members
        Dictionary<Type, object> _dictionary = new Dictionary<Type, object>();
        #endregion

        #region Singleton
        static ServiceLocator _serviceLocator = null;

        private ServiceLocator() { }
        public static ServiceLocator Instance
        {
            get
            {
                if (_serviceLocator == null)
                {
                    _serviceLocator = new ServiceLocator();
                }

                return _serviceLocator;
            }
        }
        #endregion

        public object this[Type key]
        {
            get
            {
                if (!_dictionary.ContainsKey(key))
                {
                    var userControl = Activator.CreateInstance(key) as object;
                    Debug.Assert(userControl != null);

                    _dictionary.Add(key, userControl);
                }

                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        public bool ContainsKey(Type type)
        {
            return _dictionary.ContainsKey(type);
        }

        public void Register(Type type)
        {
            if (type == null) { return; }

            RemoveExisting(type);

            _dictionary.Add(type, Activator.CreateInstance(type));
        }

        public void Load(Type type, object service)
        {
            if (service == null) { return; }

            RemoveExisting(service);

            _dictionary.Add(type, service);
        }

        public void Clear()
        {
            _dictionary.Clear();
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