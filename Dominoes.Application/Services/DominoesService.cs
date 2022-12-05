using Dominoes.Application.Exceptions;
using Dominoes.Application.Repositories;
using Dominoes.Core;

namespace Dominoes.Application.Services;

/// <summary>
/// All dominoes application logic will be handle here
/// </summary>
public class DominoesService
{
    private readonly IJornadaRepository _jornadaRepository;

    public DominoesService(IJornadaRepository jornadaRepository)
    {
        _jornadaRepository = jornadaRepository ?? throw new ArgumentNullException(nameof(jornadaRepository));
    }

    /// <summary>
    /// Gets a jornada by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>returns the jornada or null if not found</returns>
    public Jornada? GetJornadaById(Guid id)
    {
        return _jornadaRepository.FirstOrDefault(jornada => jornada.Id == id);
    }

    /// <summary>
    /// Creates a Jornada
    /// </summary>
    /// <param name="jornada"></param>
    /// <returns></returns>
    public Jornada CreateJornada(Jornada jornada)
    {
        _jornadaRepository.Add(jornada);
        return jornada;
    }

    /// <summary>
    /// Creates a player on a given jornada 
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public Player CreatesPlayerOnJornada(Guid jornadaId, Player player)
    {
        var jornada = _jornadaRepository.FirstOrDefault(j => j.Id == jornadaId);
        // check if we have a jornada
        if (jornada is null)
        {
            throw new DataNotFoundException($"Jornada with Id {jornadaId} does not exists");
        }
        
        // check if that jornada has a player with that name
        if (jornada.Players.Any(p => p.Name == player.Name))
        {
            throw new DataAlreadyExistsException($"A Player with the name {player.Name} already exists on Jornada {jornadaId}");
        }
        
        _jornadaRepository.CreatePlayerForJornada(jornadaId, player);
        return player;
    }
}