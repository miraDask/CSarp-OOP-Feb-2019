using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre : Tyre
{
    private const string InitialName = "Hard";

    public HardTyre(double hardness)
        : base(InitialName, hardness)
    {
    }
}

