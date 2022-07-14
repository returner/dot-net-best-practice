using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace SimpleReactive
{
    class Subscriber
    {
        public string Name;

        //Listen for OnNext and write to the debug window when it happens
        public Subscriber(IObservable<string> observable, string name)
        {
            Name = name;
            var disposable = observable.Subscribe((s) => Debug.WriteLine($"Name: {Name} Message: {s}"));
        }
    }

    public class Publisher : IObservable<string>
    {
        List<IObserver<string>> _observers = new List<IObserver<string>>();

        public Publisher()
        {
            Task.Run(async () =>
            {
                //Loop forever
                while (true)
                {
                    //Get some data, publish it with OnNext and wait 500 milliseconds
                    _observers.ForEach(o => o.OnNext(GetSomeData()));
                    await Task.Delay(500);
                }
            });
        }

        private string GetSomeData() => "Hi";

        public IDisposable Subscribe(IObserver<string> observer)
        {
            _observers.Add(observer);
            return Disposable.Create(() => { });
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Messaging()
        {
            var publisher = new Publisher();

            new Subscriber(publisher, "One");
            new Subscriber(publisher, "Two");

            await Task.Delay(3000);
        }
    }
}
