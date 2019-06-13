using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);
        var methods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            
        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(y => y.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}

