using ClassModule.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModule.Entities;

namespace HoloCoder.TestAPI
{
    public class MockClassServices : IClassServices
    {
        public Class LoadClass()
        {
            return new Class()
            {
                Id = "Class_1"
            };
        }
    }
}
