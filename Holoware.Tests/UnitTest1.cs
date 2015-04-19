using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bizmonger.Patterns;

namespace Holoware.Tests
{
    [TestClass]
    public class MessageBusTest
    {
        [TestMethod]
        public void pubsub()
        {
            // Setup
            var success = false;

            // Test
            MessageBus.Instance.Subscribe("my_subscription", obj => { success = true; });
            MessageBus.Instance.Publish("my_subscription", null);

            // Verify
            Assert.IsTrue(success);

            // Teardown
            MessageBus.Instance.Clear();
        }

        [TestMethod]
        public void pubsub_subscribe1stPublication()
        {
            // Setup
            var counter = 0;

            // Test
            MessageBus.Instance.SubscribeFirstPublication("my_subscription", obj => { counter++; });
            MessageBus.Instance.Publish("my_subscription", null);
            MessageBus.Instance.Publish("my_subscription", null);

            // Verify
            Assert.IsTrue(counter == 1);

            // Teardown
            MessageBus.Instance.Clear();
        }

        [TestMethod]
        public void pubsub_nested()
        {
            var rootSuccess = false;
            var nestedSuccess = false;

            // Test
            MessageBus.Instance.Subscribe("my_subscription", obj =>
                {
                    rootSuccess = true;

                    MessageBus.Instance.Subscribe("my_subscription2", obj2 =>
                        {
                            nestedSuccess = true;
                        });

                    MessageBus.Instance.Publish("my_subscription2", null);
                });

            MessageBus.Instance.Publish("my_subscription", null);

            // Verify
            Assert.IsTrue(nestedSuccess && rootSuccess);

            // Teardown
            MessageBus.Instance.Clear();
        }
    }
}
