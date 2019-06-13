using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    private RaceTower controller;

    public Engine()
    {
        this.controller = new RaceTower();
    }

    public void Run()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        this.controller.SetTrackInfo(numberOfLaps, trackLength);

        while (true)
        {
            var input = Console.ReadLine().Split();
            var command = input[0];
            var args = input.Skip(1).ToList();

            string result = string.Empty;

            if (command.Contains("Box"))
            {
                this.controller.DriverBoxes(args);
            }
            else if (command == "RegisterDriver")
            {
                this.controller.RegisterDriver(args);
            }
            else if (command == "ChangeWeather")
            {
                this.controller.ChangeWeather(args);
            }
            else if (command == "CompleteLaps")
            {
                result = this.controller.CompleteLaps(args);
                Console.WriteLine(result);
            }
            else if (command == "Leaderboard")
            {
                result = this.controller.GetLeaderboard();
                Console.WriteLine(result);
            }

        }
    }
}

