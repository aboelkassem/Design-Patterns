using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.PaymentProcessors
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            // Invoke the Stripe API
            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.CreditCard);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}
