using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.DecoratorPattern.Decorators
{
    public class SMSNotifierDecorator : NotifierDecorator
    {
        protected string phoneNumber;

        public SMSNotifierDecorator(INotifier notifier, string phoneNumber) : base(notifier)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SendSMS()
        {
            Console.WriteLine($"Sending SMS to: {phoneNumber}");
            Console.WriteLine($"You latest operation was executed successfully");
        }

        public override void notify()
        {
            base.notify();
            this.SendSMS();
        }
    }
}
