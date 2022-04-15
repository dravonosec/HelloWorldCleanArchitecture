namespace Ftsoft.Domain
{
    public interface IKey<TEntity>
    {
        TEntity New();
    }
}