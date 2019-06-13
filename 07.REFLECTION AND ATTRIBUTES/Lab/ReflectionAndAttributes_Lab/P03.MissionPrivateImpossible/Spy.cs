using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder info = new StringBuilder();

        Type classType = Type.GetType(className);

        info.AppendLine($"All Private Methods of Class: {className}");

        info.AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (MethodInfo method in privateMethods)
        {
            info.AppendLine(method.Name);
        }

        return info.ToString().Trim();
    }
}
