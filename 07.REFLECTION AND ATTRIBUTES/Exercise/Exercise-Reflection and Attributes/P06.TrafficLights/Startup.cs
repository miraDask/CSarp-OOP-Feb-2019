namespace P06.TrafficLights
{
    using P06.TrafficLights.Contracts;
    using P06.TrafficLights.Models;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            LightFactory lightFactory = new LightFactory();

            var input = Console.ReadLine().Split();
            var numberOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChanges; i++)
            {
                List<string> lights = new List<string>();

                for (int j = 0; j < input.Length; j++)
                {
                    var color = input[j];
                    ILight light = lightFactory.CreateLight(color);
                    light.ChangeLightCollor();
                    lights.Add(light.ToString());
                }

                Console.WriteLine(string.Join(" ", lights));
                input = lights.ToArray();
            }
        }
    }
}
