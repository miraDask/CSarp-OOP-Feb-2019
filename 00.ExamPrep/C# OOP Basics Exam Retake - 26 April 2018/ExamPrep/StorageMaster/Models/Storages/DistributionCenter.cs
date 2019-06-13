using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, 2, 5, new List<Vehicle>()
        {
            new Van(),
            new Van(),
            new Van()
        })
        {
        }
    }
}
