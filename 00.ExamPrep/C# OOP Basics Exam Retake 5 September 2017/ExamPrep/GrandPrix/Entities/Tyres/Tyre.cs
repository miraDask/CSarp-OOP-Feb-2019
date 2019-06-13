using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    private const double InitialDegradation = 100;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.degradation = InitialDegradation;
    }

    public string Name { get; private set; }

    public double Hardness { get; private set; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Tyre blows up!");
            }

            this.degradation = value;
        }
    }
    
    public virtual void DegradateTyre()
    {
        this.Degradation -= this.Hardness;
    }
}

