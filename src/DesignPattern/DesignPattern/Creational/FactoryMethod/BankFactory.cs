using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class BankFactory : IBankFactory
    {
        public IBank CreateBank(string bankCode)
        {
            // credit card starting numbers to define which bank belong to
            switch (bankCode)
            {
                case "123456":
                    return new BankA();
                case "111111":
                    return new BankB();
                default:
                    return null;
            }
        }
    }
}
