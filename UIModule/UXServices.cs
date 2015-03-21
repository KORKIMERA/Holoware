using Bizmonger.Patterns;
using Bizmonger.UILogic;
using MessageModule.Messaging;
using System;
using System.Windows.Controls;
using UXModule;

namespace UIModule
{
    public class UXServices
    {
        #region Members
        Subscription _subscription = new Subscription();
        Regions _regions = new Regions();
        #endregion

        #region Singleton
        static UXServices _UXServices = null;

        public static UXServices Instance
        {
            get
            {
                if (_UXServices == null)
                {
                    _UXServices = new UXServices();
                }

                return _UXServices;
            }
        }
        #endregion

        public void Register(Type viewType)
        {
            ServiceLocator.Instance.Register(viewType);
        }

        public void LoadView(Type viewType, RegionId regionId)
        {
            var view = ServiceLocator.Instance[viewType];

            switch (regionId)
            {
                case RegionId.MAIN:
                    {
                        MessageBus.Instance.Publish(UXMessage.ASSIGN_MAIN_REGION, view);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}