using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.PaymentReceivers.PaymentHandlers;
using DesignPatterns.Behavioral.TemplateMethodPattern;
using DesignPatterns.Behavioral.TemplateMethodPattern.Loggers;
using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Structural.AdapterPattern;
using DesignPatterns.Structural.CompositePattern;
using DesignPatterns.Structural.DecoratorPattern;
using DesignPatterns.Structural.DecoratorPattern.Decorators;
using DesignPatterns.Structural.FacadePattern;
using DesignPatterns.Structural.ProxyPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creational Design Pattern

            #region SingletonPattern
            //Counter counter1 = Counter.GetInstance();
            //Counter counter2 = Counter.GetInstance();
            //counter1.AddOne();
            //counter2.AddOne();

            //Console.WriteLine("counter 1:" + counter1.count.ToString());
            //Console.WriteLine("counter 2:" + counter2.count.ToString());
            //Console.WriteLine();

            //counter1.AddOne();
            //Console.WriteLine("counter 1:" + counter1.count.ToString());
            //Console.WriteLine("counter 2:" + counter2.count.ToString());
            #endregion

            #region FactoryMethodPattern

            //Console.WriteLine("Enter your card number");
            //var cardNumber = Console.ReadLine();
            //var bankCard = cardNumber.Substring(0, 6);

            //// Create bank object from the factory
            //BankFactory bankFactory = new BankFactory();
            //IBank bank = bankFactory.CreateBank(bankCard);

            //Console.WriteLine(bank.Withdraw());

            #endregion

            // Structural Design Pattern

            #region FacadePattern

            //ShoppingBasket basket = new ShoppingBasket();
            //basket.AddItem(new BasketItem { ItemId = "132", ItemPrice = 59, Quantity = 3 });
            //basket.AddItem(new BasketItem { ItemId = "456", ItemPrice = 49, Quantity = 2 });
            //basket.AddItem(new BasketItem { ItemId = "789", ItemPrice = 39, Quantity = 1 });

            //// Facade class within the client without knowing the process complexity
            //// Hiding information
            //PurchaseOrder order = new PurchaseOrder();

            //order.CreateOrder(basket, "name:aboelkassem,bank:1526465,mobile:01154321101");

            #endregion

            #region AdapterPattern
            ///// <summary>
            ///// The Client Class to pass array of employees
            ///// </summary>
            //string[,] employeesArray = new string[5,4]
            //{
            //    {"101","John","SE","10000"},
            //    {"102","Smith","SE","20000"},
            //    {"103","Dev","SSE","30000"},
            //    {"104","Pam","SE","40000"},
            //    {"105","Sara","SSE","50000"}
            //};

            //ITarget target = new EmployeeAdapter();
            //Console.WriteLine("HR system passes employee string array to Adapter\n");
            //target.ProcessCompanySalary(employeesArray);
            #endregion

            #region CompositePattern
            //// example of virtual file system 
            //// making directory as composite object and file as leaf
            //// this is the client

            //var root = new DirectoryItem("development");
            //var proj1 = new DirectoryItem("project1");
            //var proj2 = new DirectoryItem("project2");
            //root.Add(proj1);
            //root.Add(proj2);

            //proj1.Add(new FileItem("p1f1.txt", 2100));
            //proj1.Add(new FileItem("p1f2.txt", 3100));

            //var subDir1 = new DirectoryItem("sub-dir1");
            //subDir1.Add(new FileItem("p1f3.txt", 4100));
            //subDir1.Add(new FileItem("p1f4.txt", 5100));
            //proj1.Add(subDir1);

            //proj2.Add(new FileItem("p2f1.txt", 6100));
            //proj2.Add(new FileItem("p2f2.txt", 7100));

            //Console.WriteLine($"Total size (root): {root.GetSizeInKB()}KB");
            //Console.WriteLine($"Total size (proj1): {proj1.GetSizeInKB()}KB");
            //Console.WriteLine($"Total size (proj2): {proj2.GetSizeInKB()}KB");
            #endregion

            #region ProxyPattern

            //SMSServiceProxy proxy = new SMSServiceProxy();
            //Console.WriteLine(proxy.SendSMS("123", "01154321101", "message 1"));
            //Console.WriteLine(proxy.SendSMS("123", "01154321101", "message 2"));
            //Console.WriteLine(proxy.SendSMS("123", "01154321101", "message 3"));

            #endregion

            #region DecoratorPattern

            //bool smsNotificationEnabled = false;
            //bool whatsAppNotificationEnabled = true;
            //INotifier notifier = new EmailNotifier("mohamedabdelrahman9972@gmail.com");

            //// Adding SMS Notification to emailing service
            //if (smsNotificationEnabled)
            //{
            //    notifier = new SMSNotifierDecorator(notifier, "01154321101");
            //}

            //// Adding WhatsApp Notification to emailing service
            //if (whatsAppNotificationEnabled)
            //{
            //    notifier = new WhatsAppNotifierDecorator(notifier, "01154321101");
            //}

            //// Default that is sending Email
            //notifier.notify();

            #endregion

            // Behavioral Design Pattern
            #region TemplateMethodPattern
            //AbstractLogger fileLogger = new FileLogger();
            //fileLogger.Log("Message to Log in File.");

            //AbstractLogger emailLogger = new EmailLogger();
            //emailLogger.Log("Message to Log via Email.");

            //AbstractLogger databaseLogger = new DatabaseLogger();
            //databaseLogger.Log("Message to Log in DB.");
            #endregion

            #region ChainOfResponsibilityPattern
            var order = new Order();
            order.AddLineItem(new LineItem("GUID 1", "Product Name One", 499), 2);
            order.AddLineItem(new LineItem("GUID 2", "Product Name Two", 799), 1);

            order.AddPayment(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.AddPayment(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 797
            });

            Console.WriteLine($"Amount Due:      \t {order.AmountDue}");
            Console.WriteLine($"Shipping Status: \t {order.ShippingStatus}");
            Console.WriteLine();

            // chain of responsibilities with OOP No Separation Example
            // var handler = new PaypalHandler();
            // handler.SetNext(new CreditCardHandler())
            //     .SetNext(new InvoiceHandler());

            // handler.Handle(order);

            // chain of responsibilities with OOP Separation Example
            var handler = new PaymentHandler()
                .SetNext(new PaypalHandler())
                .SetNext(new InvoiceHandler())
                .SetNext(new CreditCardHandler());
            handler.Handle(order);

            Console.WriteLine($"Amount Due:      \t {order.AmountDue}");
            Console.WriteLine($"Shipping Status: \t {order.ShippingStatus}");
            #endregion
        }
    }
}