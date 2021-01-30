using DesignPatterns.Behavioral.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Observer
{
    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string ProductName { get; set; }
        private int ProductPrice { get; set; }
        private string State { get; set; }

        public Subject(string productName, int productPrice, string state)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            State = state;
        }

        public string getState()
        {
            return State;
        }
        public void setState(string state)
        {
            Console.WriteLine($"Availability changed from {this.State} to {state}.");
            this.State = state;
            NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added : " + ((Observer)observer).UserName);
            observers.Add(observer);
        }
        public void AddObservers(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name :"
                            + ProductName + ", product Price : "
                            + ProductPrice + " is Now available. So notifying all Registered users ");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.update(State);
            }
        }
    }
}
