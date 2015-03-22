using Bizmonger.Patterns;
using Bizmonger.UILogic;
using MessageModule;
using System;
using System.Windows.Controls;
using UXModule;

namespace UXModule
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
                case RegionId.CONTENT:
                    {
                        MessageBus.Instance.Publish(UXMessage.ASSIGN_CONTENT_REGION, view);
                        break;
                    }

                case RegionId.NINE_OCLOCK:
                    {
                        MessageBus.Instance.Publish(UXMessage.NINE_OCLOCK_REGION, view);
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