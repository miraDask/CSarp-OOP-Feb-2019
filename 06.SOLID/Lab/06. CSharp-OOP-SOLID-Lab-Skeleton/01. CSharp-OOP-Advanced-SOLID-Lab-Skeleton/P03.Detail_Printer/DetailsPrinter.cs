using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployable> employees;

        public DetailsPrinter(IList<IEmployable> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployable employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
