using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.PaymentProcessors
{
    public class InvoicePaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            // Create an invoice and email it

            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Invoice);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}
