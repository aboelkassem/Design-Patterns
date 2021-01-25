using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.DecoratorPattern
{
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier notifier;

        public NotifierDecorator(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public virtual void notify()
        {
            this.notifier.notify();
        }
    }
}
