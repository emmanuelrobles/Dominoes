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
    public Jornada? GetJornadaById(uint id)
    {
        return _jornadaRepository.FirstOrDefault(jornada => jornada.Id == id);
    }
    
}