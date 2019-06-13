using System;

public class Car
{
    private const double TankMaximumCapacity = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.fuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Driver cannot continue the race.");
            }

            this.fuelAmount = Math.Min(TankMaximumCapacity, value);
        }
    }

    public Tyre Tyre { get; private set; }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void Drive(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;
    }
}

