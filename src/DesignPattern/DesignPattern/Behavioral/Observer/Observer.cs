using DesignPatterns.Behavioral.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Observer
{
    public class Observer : IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this);
        }

        public void update(string state)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + state + " on Amazon");
        }
    }
}
