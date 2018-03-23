using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var emp = new Employee("mena");

            var docs = new List<string> { "doc 1", "doc 2"};
            var man = new Manager("menchi", docs);

            var emps = new List<Employee> { emp, man };

            var printer = new DetailsPrinter(emps);
            printer.PrintDetails();
        }
    }
}
