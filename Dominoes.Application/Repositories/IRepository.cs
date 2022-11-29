using System.Linq.Expressions;

namespace Dominoes.Application.Repositories;

/// <summary>
/// Base Repository interface
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Finds many entities that match the predicated
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>A set matching the predicate</returns>
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Finds many entities that match the predicated with pagination
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="page"></param>
    /// <param name="take"></param>
    /// <returns>A set matching the predicated</returns>
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,uint page, uint take);
    
    /// <summary>
    /// Finds the first entity that matches a preidcate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>The entity if found or null</returns>
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Adds an entity to the persistence layer
    /// </summary>
    /// <param name="entity"></param>
    void Add(TEntity entity);
    
    /// <summary>
    /// Adds many entities to persistence layer
    /// </summary>
    /// <param name="entities"></param>
    void AddRange(IEnumerable<TEntity> entities);
    
    /// <summary>
    /// Removes an entity from persistence
    /// </summary>
    /// <param name="entity"></param>
    void Remove(TEntity entity);
    
    /// <summary>
    /// Remove a range of entities from persistence
    /// </summary>
    /// <param name="entities"></param>
    void RemoveRange(IEnumerable<TEntity> entities);
}