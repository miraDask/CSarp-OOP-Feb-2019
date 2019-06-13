using System;
using System.Collections.Generic;
using System.Text;

public class TyreFactory
{
    public Tyre GetTyre(string name, string[] args)
    {
        if (name == "Ultrasoft")
        {
            double hardness = double.Parse(args[0]);
            double grip = double.Parse(args[1]);

            return new UltrasoftTyre(hardness, grip);
        }
        else if (name == "Hard")
        {
            double hardness = double.Parse(args[0]);

            return new HardTyre(hardness);
        }
        else
        {
            return null;
        }
    }
}

