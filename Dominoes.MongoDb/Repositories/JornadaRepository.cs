using Dominoes.Application.Repositories;
using Dominoes.Core;
using MongoDB.Driver;

namespace Dominoes.MongoDb.Repositories;

public class JornadaRepository : Repository<Jornada>, IJornadaRepository
{
    public JornadaRepository(string connectionString, string databaseName,string collectionName) : base(connectionString, databaseName,collectionName)
    {
    }

    public override void Remove(Jornada entity)
    {
        base._collection.DeleteOne(j => j.Id == entity.Id);
    }

    public override void RemoveRange(IEnumerable<Jornada> entities)
    {
        base._collection.DeleteMany(j => entities.Any(ij => ij.Id == j.Id));
    }
}