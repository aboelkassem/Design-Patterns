using DesignPatterns.Creational.Singleton;
using System;
using System.Collections.Generic;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = Counter.GetInstance();
            Counter counter2 = Counter.GetInstance();
            counter1.AddOne();
            counter2.AddOne();

            Console.WriteLine("counter 1:" + counter1.count.ToString());
            Console.WriteLine("counter 2:" + counter2.count.ToString());
            Console.WriteLine();

            counter1.AddOne();
            Console.WriteLine("counter 1:" + counter1.count.ToString());
            Console.WriteLine("counter 2:" + counter2.count.ToString());
        }
    }
}
