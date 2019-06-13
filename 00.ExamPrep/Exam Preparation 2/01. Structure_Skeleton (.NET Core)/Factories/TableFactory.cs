using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable CreateTable(string tableType, int tableNumber, int capacity)
        {
            tableType = tableType + "Table";
            //var type = Assembly
            //    .GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == tableType + "Table");

            //return (ITable)Activator
            //        .CreateInstance(type,
            //        new object[] {tableNumber, capacity});

            if (tableType == "InsideTable")
            {
                return new InsideTable(tableNumber, capacity);
            }
            else if (tableType == "OutsideTable")
            {
                return new OutsideTable(tableNumber, capacity);
            }
            else
            {
                return null;
            }
        }
    }
}
