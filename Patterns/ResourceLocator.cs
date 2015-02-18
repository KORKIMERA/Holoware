using System;
using System.Collections.Generic;

namespace Bizmonger.Patterns
{
    public class ResourceLocator : Dictionary<Type, object>
    {
        #region Singleton
        static ResourceLocator _resourceLocator = null;
        public static ResourceLocator Instance
        {
            get
            {
                if (_resourceLocator == null)
                {
                    _resourceLocator = new ResourceLocator();
                }

                return _resourceLocator;
            }
        }
        #endregion
    }
}