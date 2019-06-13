using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private const string InitialName = "Ultrasoft";
    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base(InitialName, hardness)
    {
        this.Grip = grip;
        this.degradation = base.Degradation;
    }

    public double Grip { get; private set; }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Tyre blows up!");
            }

            this.degradation = value;
        }
    }

    public override void DegradateTyre()
    {
       this.Degradation -= (this.Hardness + this.Grip);
    }
}

