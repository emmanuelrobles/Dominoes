using System.Linq.Expressions;
using Dominoes.Application.Repositories;
using MongoDB.Driver;

namespace Dominoes.MongoDb.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{

    protected readonly IMongoCollection<TEntity> _collection;
    
    protected Repository(string connectionString, string databaseName ,string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<TEntity>(collectionName);
    }
    
    /// <summary>
    /// Finds all entities that match an expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _collection.Find(predicate).ToEnumerable();
    }

    /// <summary>
    /// Find many entities given an expression and return a set of that set 
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="page"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, uint page, uint take)
    {
        // some casting to accomodate to function signature
        var skip = (page * take) - take as int?; // function to get the skip value
        var takeInt = take as int?;
        
        if (skip is null || takeInt is null)
        {
            return Enumerable.Empty<TEntity>();
        }
        return _collection.Find(predicate).Skip(skip).Limit(takeInt).ToEnumerable();
    }

    /// <summary>
    /// Find an entity that match a predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _collection.Find(predicate).FirstOrDefault();
    }

    /// <summary>
    /// Adds an entity
    /// </summary>
    /// <param name="entity"></param>
    public void Add(TEntity entity)
    {
        _collection.InsertOne(entity);
    }

    /// <summary>
    /// Adds many entities
    /// </summary>
    /// <param name="entities"></param>
    public void AddRange(IEnumerable<TEntity> entities)
    {
        _collection.InsertMany(entities);
    }

    /// <summary>
    /// Remove an entity
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Remove(TEntity entity);

    /// <summary>
    /// Remove many entities
    /// </summary>
    /// <param name="entities"></param>
    public abstract void RemoveRange(IEnumerable<TEntity> entities);
}