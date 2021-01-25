using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.DecoratorPattern.Decorators
{
    public class WhatsAppNotifierDecorator : NotifierDecorator
    {
        protected string phoneNumber;

        public WhatsAppNotifierDecorator(INotifier notifier, string phoneNumber) : base(notifier)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SendSMS()
        {
            Console.WriteLine($"Sending WhatsApp message to: {phoneNumber}");
            Console.WriteLine($"You latest operation was executed successfully");
        }

        public override void notify()
        {
            base.notify();
            this.SendSMS();
        }
    }
}
