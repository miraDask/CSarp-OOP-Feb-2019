namespace p09.CollectionHierarchy.Collections
{
    public class AddCollection : BaseCollection
    {
        public override int Add(string element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}
