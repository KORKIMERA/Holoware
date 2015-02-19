using BaseModule;
using ClassModule.Entities;

namespace ClassModule.Infrastructure
{
    public interface IClassServices : IModule
    {
        Class LoadClass();
    }
}