namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            //switch (type)
            //{
            //	case "LightAirplane":
            //		return new LightAirplane();
            //	case "MediumAirplane":
            //		return new MediumAirplane();
            //	default:
            //		return new Airplane();
            //}

            var planeType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return (IAirplane)Activator.CreateInstance(planeType);
		}
	}
}