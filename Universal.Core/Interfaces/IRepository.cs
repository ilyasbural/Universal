namespace Universal.Core
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task InsertAsync(T Entity);
        Task<List<T>> SelectAsync(System.Linq.Expressions.Expression<Func<T, bool>> Predicate);
    }
}