namespace p10.ExplicitInterfaces
{
    using System;

    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
