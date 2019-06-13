namespace p03.Ferrari
{
    public interface ICar
    {
        string Model { get; }

        string DriverName { get; }

        string UseBrakes();

        string PushTheGasPedal();
    }
}
