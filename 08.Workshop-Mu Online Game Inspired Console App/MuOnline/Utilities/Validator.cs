namespace MuOnline.Utilities
{
    using System;

    public static class Validator
    {
        private const string exitCommand = "exit";

        public static void ValidateIntArgValue(int value, string argument)
        {
            if (value < 0)
            {
                throw new ArgumentNullException($"{argument} cannot be less than zero!");
            }
        }

        public static void ValidateStringArgValue(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{value} cannot be null!");
            }
        }

        public static void IsAliveValidation(bool isAlive)
        {
            if (isAlive == false)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }
        }

        public static void ObjecIsNotNullValidation(object arg)
        {
            if (arg == null)
            {
                throw new ArgumentException($"Invalid command");
            }
        }

        public static void InputLengthValidate(string[] inputArgs)
        {
            var firstArg = inputArgs[0];

            if ((inputArgs.Length < 2 && firstArg.ToLower() != exitCommand)
                || string.IsNullOrEmpty(firstArg) 
                || string.IsNullOrWhiteSpace(firstArg))
            {
                throw new ArgumentException($"Invalid command");
            }
        }
    }
}
