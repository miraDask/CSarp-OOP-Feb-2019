namespace p09.CollectionHierarchy.Collections
{
    using Interfaces;
    using System.Collections.Generic;

    public abstract class BaseCollection : IAddable
    {
       protected List<string> Collection { get; private set; } = new List<string>();

        public virtual int Add(string element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }
    }
}
