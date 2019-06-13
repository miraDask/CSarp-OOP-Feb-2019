namespace p09.CollectionHierarchy.Collections
{
    using Interfaces;

    public abstract class BaseAddAndRemoveCollection : BaseCollection, IAdderAndRemover
    {
        public abstract string Remove();
    }
}
