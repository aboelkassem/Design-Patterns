using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// target interface to be implemented in adapter class
    /// </summary>
    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }
}
