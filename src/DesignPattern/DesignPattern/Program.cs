using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Structural.AdapterPattern;
using DesignPatterns.Structural.FacadePattern;
using System;
using System.Collections;
using System.Collections.Generic;


namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
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
            /// <summary>
            /// The Client Class to pass array of employees
            /// </summary>
            string[,] employeesArray = new string[5,4]
            {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
            };

            ITarget target = new EmployeeAdapter();
            Console.WriteLine("HR system passes employee string array to Adapter\n");
            target.ProcessCompanySalary(employeesArray);
            #endregion
        }
    }
}