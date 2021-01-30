using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Observer.Interfaces
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}
