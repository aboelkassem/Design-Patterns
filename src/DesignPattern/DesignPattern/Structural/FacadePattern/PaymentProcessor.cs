using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.FacadePattern
{
    public class PaymentProcessor
    {
        public bool HandlePayment(double amount, string bankInfo)
        {
            return true;
        }
    }
}
