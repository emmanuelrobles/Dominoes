using Dominoes.Application.Repositories;
using Dominoes.Core;
using MongoDB.Bson;
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

    public void CreatePlayerForJornada(Guid jornadaId, Player player)
    {
        // push a new player to the players array on jornada
        var arrPush = Builders<Jornada>.Update.Push(nameof(Jornada.Players), player);
        _collection.UpdateOne(jornada => jornada.Id == jornadaId, arrPush);
    }

    public void DeletesPlayerOnJornada(Guid jornadaId, Guid playerId)
    {
        throw new NotImplementedException();
    }

    public void CreateEncounterForPlayer(Guid jornadaId, Guid playerId, Encounter encounter)
    {
        throw new NotImplementedException();
    }

    public void UpdateEncounterForPlayer(Guid jornadaId, Guid playerId, Encounter encounter)
    {
        throw new NotImplementedException();
    }

    public void DeleteEncounter(Guid jornadaId, Guid playerId, Guid encounterId)
    {
        throw new NotImplementedException();
    }
}