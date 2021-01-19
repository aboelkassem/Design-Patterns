using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class BankA : IBank
    {
        public string Withdraw()
        {
            return "Your request is handling by BankA";
        }
    }
}
