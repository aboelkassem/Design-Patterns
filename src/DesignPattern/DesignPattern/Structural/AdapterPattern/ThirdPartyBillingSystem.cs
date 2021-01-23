using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Service/Adaptee Class
    /// </summary>
    public class ThirdPartyBillingSystem
    {
        //ThirdPartyBillingSystem accepts employees information as a List to process each employee salary List<Employee>
        public void ProcessSalary(List<Employee> listEmployee)
        {
            foreach (Employee employee in listEmployee)
            {
                Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
            }
        }
    }
}
