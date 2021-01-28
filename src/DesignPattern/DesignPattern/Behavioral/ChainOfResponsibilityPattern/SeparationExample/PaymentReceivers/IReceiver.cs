using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers
{
    public interface IReceiver<in T> where T : class
    {
        void Handle(T request);
    }
}
