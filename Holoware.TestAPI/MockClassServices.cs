using ClassModule.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModule.Entities;

namespace Holoware.TestAPI
{
    public class MockClassServices : IClassServices
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Class LoadClass()
        {
            return new Class()
            {
                Id = "Class_1"
            };
        }
    }
}
