using DesignPatterns.Creational.FactoryMethod;
using DesignPatterns.Creational.Singleton;
using System;
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

            Console.WriteLine("Enter your card number");
            var cardNumber = Console.ReadLine();
            var bankCard = cardNumber.Substring(0, 6);

            // Create bank object from the factory
            BankFactory bankFactory = new BankFactory();
            IBank bank = bankFactory.CreateBank(bankCard);

            Console.WriteLine(bank.Withdraw());

            #endregion
        }
    }
}
