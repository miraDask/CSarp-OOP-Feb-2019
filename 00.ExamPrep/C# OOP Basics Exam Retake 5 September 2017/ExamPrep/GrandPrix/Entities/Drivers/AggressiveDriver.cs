using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{
    private const double InitialFuelConsumptionPerKm = 2.7;
    private const double SpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, InitialFuelConsumptionPerKm)
    {
    }

    public override double Speed => base.Speed * SpeedMultiplier;
}

