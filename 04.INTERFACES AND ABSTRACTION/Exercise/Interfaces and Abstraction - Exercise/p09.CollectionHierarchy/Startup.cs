namespace p09.CollectionHierarchy
{
    using p09.CollectionHierarchy.Collections;
    using p09.CollectionHierarchy.Interfaces;
    using System;

    public class Startup
    {
        public static void Main()
        {
            AddCollection addcollection = new AddCollection();
            AddRemoveCollection addAndRemoveCollection = new AddRemoveCollection();
            MyList mylist = new MyList();

            string[] elementsForAdding = Console.ReadLine().Split();
            int removeOperationsCount = int.Parse(Console.ReadLine());

            int[] addCollectonAddingResult = GetAddingResult(elementsForAdding, addcollection);

            Console.WriteLine(string.Join(" ", addCollectonAddingResult));

            int[] addAndRemoveCollectionAddingResult = GetAddingResult(elementsForAdding, addAndRemoveCollection);

            Console.WriteLine(string.Join(" ", addAndRemoveCollectionAddingResult));

            int[] myListAddingResult = GetAddingResult(elementsForAdding, mylist);

            Console.WriteLine(string.Join(" ", myListAddingResult));

            string[] addAndRemoveCollectionRemovingResult = GetRemovingResult(removeOperationsCount, addAndRemoveCollection);

            Console.WriteLine(string.Join(" ", addAndRemoveCollectionRemovingResult));

            string[] myListRemovingResult = GetRemovingResult(removeOperationsCount, mylist);

            Console.WriteLine(string.Join(" ", myListRemovingResult));
        }

        private static string[] GetRemovingResult(int removeOperationsCount, IAdderAndRemover addAndRemoveCollection)
        {
            string[] result = new string[removeOperationsCount];

            for (int i = 0; i < removeOperationsCount; i++)
            {
                result[i] = addAndRemoveCollection.Remove();
            }

            return result;
        }

        private static int[] GetAddingResult(string[] elementsForAdding, IAddable addcollection)
        {
            int[] result = new int[elementsForAdding.Length];

            for (int i = 0; i < result.Length ; i++)
            {
                string currentElement = elementsForAdding[i];
                result[i] = addcollection.Add(currentElement);
            }

            return result;
        }
    }
}
