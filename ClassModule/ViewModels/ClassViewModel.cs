using ClassModule.Entities;
using ClassModule.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModule.ViewModels
{
    public class ClassViewModel
    {
        #region Members
        IClassServices _services = null;
        #endregion

        public Class LoadClass()
        {
            return _services.LoadClass();
        }

        public void Initialize(ClassDependencies dependencies)
        {
            _services = dependencies.Services;
        }
    }
}