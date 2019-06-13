namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new RandomList();

            randomList.Add("text");
            randomList.Add("text1");
            randomList.Add("text2");
            randomList.Add("text3");
            randomList.Add("text4");

            while (randomList.Count != 0)
            {
                Console.WriteLine(randomList.RandomString());
            }
        }
    }
}
