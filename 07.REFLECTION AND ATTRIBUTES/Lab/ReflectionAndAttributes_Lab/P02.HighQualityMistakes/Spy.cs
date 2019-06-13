using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        StringBuilder info = new StringBuilder();

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (FieldInfo field in fields)
        {
            info.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] privateMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.Name.StartsWith("get")).ToArray();

        foreach (MethodInfo method in privateMethods)
        {
            info.AppendLine($"{method.Name} have to be public!");
        }

        MethodInfo[] publicMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.Name.StartsWith("set")).ToArray();

        foreach (MethodInfo method in publicMethods)
        {
            info.AppendLine($"{method.Name} have to be private!");
        }

        return info.ToString().TrimEnd();
    }
}
