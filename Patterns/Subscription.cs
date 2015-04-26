using System;
using System.Collections.Generic;
using System.Linq;

namespace Bizmonger.Patterns
{
    public class Subscription
    {
        #region Members
        Dictionary<string, List<Observer>> _observerList = new Dictionary<string, List<Observer>>();
        #endregion

        public void Unsubscribe(string subscription)
        {
            List<Observer> observers = null;
            var observersFound = _observerList.TryGetValue(subscription, out observers);

            if (!observersFound)
            {
                return;
            }

            foreach (var observer in observers)
            {
                MessageBus.Instance.Unsubscribe(observer.Subscription, observer.Respond);
            }

            List<Observer> observers2 = null;
            var observers2Found = _observerList.TryGetValue(subscription, out observers2);

            observers2?.ToList().ForEach(o => _observerList.Remove(o.Subscription));
        }

        public void Subscribe(string subscription, Action<object> response)
        {
            var observer = new Observer() { Subscription = subscription, Respond = response };

            MessageBus.Instance.Subscribe(subscription, response);

            List<Observer> observers = null;
            var observersFound = _observerList.TryGetValue(subscription, out observers);

            if (!observersFound)
            {
                observers = new List<Observer>() { observer };

                _observerList.Add(subscription, observers);
            }
            else
            {
                observers.Add(observer);
            }
        }

        public void SubscribeFirstPublication(string subscription, Action<object> response)
        {
            MessageBus.Instance.SubscribeFirstPublication(subscription, response);
        }
    }
}