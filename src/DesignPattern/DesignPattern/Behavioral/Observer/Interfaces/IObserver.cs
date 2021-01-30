using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Observer.Interfaces
{
    public interface IObserver
    {
        void update(string availability);
    }
}
