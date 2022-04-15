namespace Ftsoft.Domain
{
    public abstract class Entity<TKey> : Entity
    {
        protected Entity(TKey key)
        {
            Key = key;
        }

        protected Entity()
        {

        }

        public TKey Key { get; private set; }
    }
}