namespace P06.TrafficLights.Models
{
    using P06.TrafficLights.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    public class LightFactory
    {
        public ILight CreateLight(string color)
        {
            var lightColor = Enum.Parse<LightSignal>(color);

            var classType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == nameof(Light));

            var instance =(ILight)Activator.CreateInstance(classType, new object[] {lightColor});
            return instance;
        }
    }
}
