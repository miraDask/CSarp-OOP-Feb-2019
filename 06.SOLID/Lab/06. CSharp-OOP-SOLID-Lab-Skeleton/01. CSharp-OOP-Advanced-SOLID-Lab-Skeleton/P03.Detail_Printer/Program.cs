using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployable manager = new Manager("Gogo", new List<string>() {"azbuka", "kokoshka", "vivi" });
            IEmployable manager2 = new Manager("Pesho", new List<string>() {"obuvka", "lisica", "vivi2" });
            DetailsPrinter printer = new DetailsPrinter(new List<IEmployable>() {manager, manager2 });
            printer.PrintDetails();
        }
    }
}
