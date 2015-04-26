using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bizmonger.Patterns
{
    public class MessageBus
    {
        #region Singleton
        static MessageBus _messageBus = null;
        private MessageBus() { }

        public static MessageBus Instance
        {
            get
            {
                if (_messageBus == null)
                {
                    _messageBus = new MessageBus();
                }

                return _messageBus;
            }
        }
        #endregion

        #region Members
        Dictionary<string, List<Observer>> _observers = new Dictionary<string, List<Observer>>();
        Dictionary<string, List<Observer>> _oneTimeObservers = new Dictionary<string, List<Observer>>();
        Dictionary<string, List<Observer>> _waitingSubscribers = new Dictionary<string, List<Observer>>();
        Dictionary<string, List<Observer>> _waitingUnsubscribers = new Dictionary<string, List<Observer>>();

        int _publishingCount = 0;
        #endregion

        public void Subscribe(string subscription, Action<object> response)
        {
            Subscribe(subscription, response, _observers);
        }

        public void SubscribeFirstPublication(string subscription, Action<object> response)
        {
            Subscribe(subscription, response, _oneTimeObservers);
        }

        public int Unsubscribe(string subscription, Action<object> response)
        {
            List<Observer> observersToUnsubscribe = null;
            var found = _observers.TryGetValue(subscription, out observersToUnsubscribe);

            var waitingSubscribers = new List<Observer>();
            _waitingSubscribers.Values.ToList().ForEach(o => waitingSubscribers.AddRange(o));
            observersToUnsubscribe.AddRange(waitingSubscribers.Where(o => o.Respond == response));

            var oneTimeObservers = new List<Observer>();
            _oneTimeObservers.Values.ToList().ForEach(o => oneTimeObservers.AddRange(o));
            observersToUnsubscribe.AddRange(oneTimeObservers.Where(o => o.Respond == response));

            if (_publishingCount == 0)
            {
                observersToUnsubscribe.ForEach(o => _observers.Remove(o.Subscription));
            }

            else
            {
                waitingSubscribers.AddRange(observersToUnsubscribe);
            }

            return observersToUnsubscribe.Count;
        }

        public int Unsubscribe(string subscription)
        {
            List<Observer> foundObservers = null;
            var found = _observers.TryGetValue(subscription, out foundObservers);

            if (!found)
            {
                foundObservers = new List<Observer>();
                _observers.Add(subscription, foundObservers);
            }

            foundObservers.AddRange(_waitingSubscribers[subscription]);
            foundObservers.AddRange(_oneTimeObservers[subscription]);

            if (_publishingCount == 0)
            {
                _observers.Remove(subscription);
            }

            else
            {
                _waitingUnsubscribers[subscription]?.AddRange(foundObservers);
            }

            return foundObservers.Count;
        }

        public void Publish(string subscription, object payload = null)
        {
            _publishingCount++;

            Publish(_observers, subscription, payload);
            Publish(_oneTimeObservers, subscription, payload);
            Publish(_waitingSubscribers, subscription, payload);

            _oneTimeObservers.Remove(subscription);
            _waitingUnsubscribers.Clear();

            _publishingCount--;
        }

        private void Publish(Dictionary<string, List<Observer>> observers, string subscription, object payload)
        {
            Debug.Assert(_publishingCount >= 0);

            List<Observer> foundObservers = null;
            observers.TryGetValue(subscription, out foundObservers);

            foundObservers?.ToList().ForEach(o => o.Respond(payload));
        }

        public IEnumerable<Observer> GetObservers(string subscription)
        {
            List<Observer> foundObservers = null;
            _observers.TryGetValue(subscription, out foundObservers);

            return foundObservers;
        }

        public void Clear()
        {
            _observers.Clear();
            _oneTimeObservers.Clear();
        }

        #region Helpers
        private void Subscribe(string subscription, Action<object> response, Dictionary<string, List<Observer>> observers)
        {
            Debug.Assert(_publishingCount >= 0);

            var observer = new Observer() { Subscription = subscription, Respond = response };

            if (_publishingCount == 0)
            {
                Add(subscription, observers, observer);
            }
            else
            {
                Add(subscription, _waitingSubscribers, observer);
            }
        }

        private static void Add(string subscription, Dictionary<string, List<Observer>> observers, Observer observer)
        {
            List<Observer> foundObservers = null;
            var observersExist = observers.TryGetValue(subscription, out foundObservers);

            if (observersExist)
            {
                foundObservers.Add(observer);
            }
            else
            {
                foundObservers = new List<Observer>() { observer };
                observers.Add(subscription, foundObservers);
            }
        }
        #endregion
    }
}