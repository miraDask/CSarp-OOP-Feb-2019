namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(string[] data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }
        }
    }
}
