using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Handlers.PaymentHandlers
{
    public class CreditCardHandler : PaymentHandler
    {
        public CreditCardPaymentProcessor CreditCardPaymentProcessor { get; }
            = new CreditCardPaymentProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }

            base.Handle(order);
        }
    }
}
