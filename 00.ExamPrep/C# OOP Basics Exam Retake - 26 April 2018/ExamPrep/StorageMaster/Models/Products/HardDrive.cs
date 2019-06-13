using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double InitialWeight = 1;

        public HardDrive(double price)
            : base(price, InitialWeight)
        {
        }
    }
}
