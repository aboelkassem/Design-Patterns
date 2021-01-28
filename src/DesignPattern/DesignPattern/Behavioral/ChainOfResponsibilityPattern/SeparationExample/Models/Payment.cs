using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }

    public enum PaymentProvider
    {
        Paypal,
        CreditCard,
        Invoice
    }
}
