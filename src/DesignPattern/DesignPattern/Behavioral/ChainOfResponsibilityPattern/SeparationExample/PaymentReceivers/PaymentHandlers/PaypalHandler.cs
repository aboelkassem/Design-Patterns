using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models;
using System.Linq;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers.PaymentHandlers
{
    public class PaypalHandler : IReceiver<Order>
    {
        public void Handle(Order order)
        {
            // Invoke the Paypal API to finalize payment

            var payment = order.SelectedPayments.FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Paypal);

            if (payment == null) return;

            order.FinalizePayment(payment);
        }
    }
}
