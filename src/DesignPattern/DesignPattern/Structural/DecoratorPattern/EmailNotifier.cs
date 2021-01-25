using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.DecoratorPattern
{
    public class EmailNotifier : INotifier
    {
        public string email;

        public EmailNotifier(string email)
        {
            this.email = email;
        }

        public void notify()
        {
            Console.WriteLine($"Sending email to: {email}");
            Console.WriteLine($"You latest operation was executed successfully");
        }
    }
}
