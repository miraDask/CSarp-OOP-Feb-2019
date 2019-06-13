using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const int OvertakingInterval = 2;
    private const int SpesialCasesOvertakingInterval = 3;
    private const string InitialWeather = "Sunny";

    private Track track;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private int currentLap;
    private Dictionary<string, Driver> drivers;
    private Dictionary<string, string> failures;
    private string weather;

    public RaceTower()
    {
        this.track = new Track();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.currentLap = 0;
        this.drivers = new Dictionary<string, Driver>();
        this.failures = new Dictionary<string, string>();
        this.weather = InitialWeather;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track.LapsNumber = lapsNumber;
        this.track.TrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        var type = commandArgs[0];
        var name = commandArgs[1];
        var hp = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);
        var tyreType = commandArgs[4];
        var tyreArgs = commandArgs.Skip(5).ToArray();

        try
        {
            var tyre = this.tyreFactory.GetTyre(tyreType, tyreArgs);
            var car = new Car(hp, fuelAmount, tyre);
            var driver = this.driverFactory.GetDriver(type, name, car);
            this.drivers[driver.Name] = driver;
        }
        catch (Exception)
        {
            return;
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0]; //ChangeTyres or Refuel
        var driversName = commandArgs[1];
        var driver = this.drivers[driversName];

        if (reasonToBox == "ChangeTyres")
        {
            var tyreType = commandArgs[2];
            var tyreArgs = commandArgs.Skip(3).ToArray();
            var newTyre = this.tyreFactory.GetTyre(tyreType, tyreArgs);
            driver.Car.ChangeTyres(newTyre);
        }
        else if (reasonToBox == "Refuel")
        {
            var fuelAmount = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuelAmount);
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder result = new StringBuilder();

        var numberOfLaps = int.Parse(commandArgs[0]);

        for (int i = 0; i < numberOfLaps; i++)
        {
            if (currentLap + 1 > this.track.LapsNumber)
            {
                throw new InvalidOperationException();
            }


            currentLap++;

            //1.Reduce FuelAmount by: “trackLength* driver’s fuelConsumptionPerKm”.
            //2.Degradate tyre according to its type

            foreach (var kvp in this.drivers)
            {
                var driverName = kvp.Key;
                var driver = kvp.Value;

                try
                {
                    driver.Car.Drive(this.track.TrackLength, driver.FuelConsumptionPerKm);
                }
                catch (Exception)
                {
                    this.failures[driverName] = "Out of fuel";
                    //throw
                }

                try
                {
                    driver.Car.Tyre.DegradateTyre();
                }
                catch (Exception ex)
                {
                    this.failures[driverName] = "Blown Tyre";
                    //throw
                }

                if (!failures.ContainsKey(driverName))
                {
                    driver.TotalTime += 60 / (this.track.TrackLength / driver.Speed);
                }
            }

            result.AppendLine(this.Overtaking(currentLap));

        }

        return result.ToString().TrimEnd();

    }

    public string GetLeaderboard()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Lap {this.currentLap}/{this.track.LapsNumber}");

        var positionNumber = 1;

        foreach (var kvp in this.drivers.OrderByDescending(x => x.Value.TotalTime))
        {
            var driverName = kvp.Key;
            var driver = kvp.Value;
            var aditionalInfo = this.failures.ContainsKey(driverName)
                ? this.failures[driverName] : $"{driver.TotalTime:f3}";

            result.AppendLine($"{positionNumber} {driverName} {aditionalInfo}");
            positionNumber++;
        }

        return result.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var newWeather = commandArgs[0];
        this.weather = newWeather;
    }

    private string Overtaking(int lap)
    {
        StringBuilder result = new StringBuilder();

        Driver slowerDriver = null;
        int count = 0;

        foreach (var kvp in this.drivers.OrderBy(x => x.Value.Speed))
        {
            var driverName = kvp.Key;
            var driver = kvp.Value;

            if (count == 0)
            {
                slowerDriver = driver;
                count++;
                continue;
            }

            bool isSpesialCaseAggressiveDriver =
                slowerDriver.GetType().Name == "AggressiveDriver"
                && slowerDriver.Car.Tyre.GetType().Name == "UltrasoftTyre";

            bool isSpesialCaseEnduranceDriver =
                 slowerDriver.GetType().Name == "EnduranceDriver"
                 && slowerDriver.Car.Tyre.GetType().Name == "HardTyre";

            var overTackingInterval = OvertakingInterval;

            if (isSpesialCaseAggressiveDriver || isSpesialCaseEnduranceDriver)
            {
                overTackingInterval = SpesialCasesOvertakingInterval;
            }

            bool overTacingIsPossible = driver.TotalTime - slowerDriver.TotalTime <= overTackingInterval;

            if (overTacingIsPossible)
            {
                if ((isSpesialCaseAggressiveDriver && this.weather == "Foggy")
               || (isSpesialCaseEnduranceDriver && this.weather == "Rainy"))
                {
                    this.failures[driverName] = "Crashed";
                }
                else
                {
                    slowerDriver.TotalTime -= overTackingInterval;
                    driver.TotalTime += overTackingInterval;
                }

                result.AppendLine($"{slowerDriver.Name} has overtaken {driver.Name} on lap {lap}.");
            }

            slowerDriver = driver;
        }

        return result.ToString().TrimEnd();
    }
}
