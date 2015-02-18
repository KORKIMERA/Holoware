using System;

namespace Bismonger.Patterns
{
    public class Observer
    {
        public Action<object> Respond { get; set; }
        public string  Subscription { get; set; }
    }
}