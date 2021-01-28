using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models;
using System.Linq;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers.PaymentHandlers
{
    public class CreditCardHandler : IReceiver<Order>
    {
        public void Handle(Order order)
        {
            // Invoke the Stripe API
            var payment = order.SelectedPayments.FirstOrDefault(x => x.PaymentProvider == PaymentProvider.CreditCard);

            if (payment == null) return;

            order.FinalizePayment(payment);
        }
    }
}
