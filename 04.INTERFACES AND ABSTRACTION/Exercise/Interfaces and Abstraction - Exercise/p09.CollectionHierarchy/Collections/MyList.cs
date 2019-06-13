namespace p09.CollectionHierarchy.Collections
{
    using p09.CollectionHierarchy.Interfaces;
    using System;
    using System.Linq;

    public class MyList : BaseAddAndRemoveCollection, IUsable
    {
        public int Used => this.Collection.Count;

        public override string Remove()
        {
            if (this.Collection.Any())
            {
                string element = this.Collection.First();
                this.Collection.RemoveAt(0);
                return element;
            }

            throw new InvalidOperationException();
        }
    }
}
