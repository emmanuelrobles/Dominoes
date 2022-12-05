using Dominoes.Core;

namespace Dominoes.Application.Repositories;

/// <summary>
/// Repo for jornadas
/// </summary>
public interface IJornadaRepository : IRepository<Jornada>
{
    /// <summary>
    /// Creates a player for a given jornada
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="player"></param>
    public void CreatePlayerForJornada(Guid jornadaId, Player player);
    
    /// <summary>
    /// Deletes a player on a given jornada
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="playerId"></param>
    public void DeletesPlayerOnJornada(Guid jornadaId, Guid playerId);
    
    /// <summary>
    /// Creates an encounter for a player on a jornada
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="playerId"></param>
    /// <param name="encounter"></param>
    public void CreateEncounterForPlayer(Guid jornadaId, Guid playerId, Encounter encounter);
    
    /// <summary>
    /// Updates an encounter for a player on a jornada
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="playerId"></param>
    /// <param name="encounter"></param>
    public void UpdateEncounterForPlayer(Guid jornadaId, Guid playerId, Encounter encounter);

    /// <summary>
    /// Deletesen encounter for a given player on a jornada 
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="playerId"></param>
    /// <param name="encounterId"></param>
    public void DeleteEncounter(Guid jornadaId, Guid playerId, Guid encounterId);
}