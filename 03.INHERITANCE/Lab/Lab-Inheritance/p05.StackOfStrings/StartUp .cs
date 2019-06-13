namespace CustomStack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new string[] {"asd", "wer", "rfb" });

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Count);
        }
    }
}
