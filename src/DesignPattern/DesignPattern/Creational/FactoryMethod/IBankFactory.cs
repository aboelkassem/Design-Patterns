using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.FactoryMethod
{
    public interface IBankFactory
    {
        IBank CreateBank(string bankCode);
    }
}
