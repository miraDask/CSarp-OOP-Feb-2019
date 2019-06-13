using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Models.Factories
{
    public class StorageFactory
    {
        public Storage GetStorage(string storageType, string name)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == storageType);

            return (Storage)Activator
                    .CreateInstance(type,
                    new object[] {name});
        }
    }
}
