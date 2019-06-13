using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfTheClassToInvestigate, params string[] namesOfTheFieldsToInvestigate)
    {
        // Type classType = Assembly
        //.GetExecutingAssembly()
        //.GetTypes()
        //.FirstOrDefault(x => x.Name == nameOfTheClassToInvestigate);

        Type classType = Type.GetType(nameOfTheClassToInvestigate);
        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(f => namesOfTheFieldsToInvestigate.Contains(f.Name)).ToArray();

        var classInctance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder info = new StringBuilder();
        info.AppendLine($"Class under investigation: {nameOfTheClassToInvestigate}");

        foreach (FieldInfo field in classFields)
        {
            info.AppendLine($"{field.Name} = {field.GetValue(classInctance)}");
        }

        return info.ToString().TrimEnd();
    }
}
