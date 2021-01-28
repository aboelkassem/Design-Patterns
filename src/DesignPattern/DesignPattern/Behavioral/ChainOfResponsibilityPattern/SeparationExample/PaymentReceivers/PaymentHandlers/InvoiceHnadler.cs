using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models;
using System.Linq;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order>
    {
        public void Handle(Order order)
        {
            // Create an invoice and email it

            var payment = order.SelectedPayments.FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Invoice);

            if (payment == null) return;

            order.FinalizePayment(payment);
        }
    }
}
