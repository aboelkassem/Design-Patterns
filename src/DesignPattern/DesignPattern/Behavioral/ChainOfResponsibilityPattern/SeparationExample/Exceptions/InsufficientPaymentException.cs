using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Exceptions
{
    public class InsufficientPaymentException : Exception
    {
        public InsufficientPaymentException() : base()
        {
        }

        public InsufficientPaymentException(string message) : base(message)
        {
        }

        public InsufficientPaymentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message
        {
            get
            {
                return "Sorry, this payment doesn't have sufficient money for complete the order";
            }
        }
    }
}
