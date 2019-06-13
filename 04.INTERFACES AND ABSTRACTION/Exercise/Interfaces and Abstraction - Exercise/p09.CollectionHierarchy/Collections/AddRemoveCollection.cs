namespace p09.CollectionHierarchy.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddRemoveCollection : BaseAddAndRemoveCollection
    {

        public override string Remove()
        {
            if (this.Collection.Any())
            {
                string lastElement = this.Collection.Last();
                this.Collection.RemoveAt(this.Collection.Count - 1);
                return lastElement;
            }
            else
            {
                throw new InvalidOperationException();
            }
            
        }
    }
}
