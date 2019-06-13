namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var constructor = classType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            var instance = constructor.Invoke(new object[] { 0 });

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] methodsArgs = input.Split('_');
                var methodName = methodsArgs[0];
                var methodParameter = int.Parse(methodsArgs[1]);
               
                var currantMethod = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

                currantMethod.Invoke(instance, new object[] {methodParameter});

                var field = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}
