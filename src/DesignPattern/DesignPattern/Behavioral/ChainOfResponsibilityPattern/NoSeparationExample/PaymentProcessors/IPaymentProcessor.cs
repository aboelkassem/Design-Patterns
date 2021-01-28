using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        void Finalize(Order order);
    }
}
