using System.Linq.Expressions;

namespace Dominoes.Application.Repositories;

/// <summary>
/// Base Repository interface
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,uint page, uint take);
    
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
        
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}