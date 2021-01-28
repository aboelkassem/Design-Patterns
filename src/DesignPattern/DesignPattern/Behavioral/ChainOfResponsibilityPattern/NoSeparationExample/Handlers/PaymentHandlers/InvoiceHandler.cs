using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Handlers.PaymentHandlers
{
    public class InvoiceHandler : PaymentHandler
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; }
            = new InvoicePaymentProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }
            base.Handle(order);
        }
    }
}
