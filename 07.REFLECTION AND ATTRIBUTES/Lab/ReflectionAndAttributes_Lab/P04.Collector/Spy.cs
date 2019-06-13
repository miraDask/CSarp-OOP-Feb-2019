using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder info = new StringBuilder();

        Type classType = Type.GetType(className);

        MethodInfo[] methods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);


        foreach (MethodInfo getter in methods.Where(x => x.Name.StartsWith("get")))
        {
            info.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (MethodInfo setter in methods.Where(x => x.Name.StartsWith("set")))
        {
            info.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return info.ToString().Trim();
    }
}
