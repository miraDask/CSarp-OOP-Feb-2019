namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, Clarity clarity)
        {
            var classType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == gemType);

           return (IGem)Activator.CreateInstance(classType, new object[] {clarity});
        }
    }
}
