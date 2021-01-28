using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Exceptions;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.NoSeparationExample.Handlers
{
    public abstract class PaymentHandler : IHandler<Order>
    {
        private IHandler<Order> Next { get; set; }

        public virtual void Handle(Order order)
        {
            Console.WriteLine($"Running: {GetType().Name}");

            if (Next == null && order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }

            if (order.AmountDue > 0)
            {
                Next.Handle(order);
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            Next = next;

            return Next;
        }
    }
}
