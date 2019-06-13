using System;
using System.Collections.Generic;
using System.Text;


public class DriverFactory
{
    public Driver GetDriver(string type, string name, Car car)
    {
        if (type == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }
        else if (type == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }
        else
        {
            return null;
        }
    }
}

