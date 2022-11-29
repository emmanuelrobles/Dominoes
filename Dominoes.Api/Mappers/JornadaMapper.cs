using Dominoes.Api.Models;
using Dominoes.Core;

namespace Dominoes.Api.Mappers;

/// <summary>
/// Static class that handles the mapping for Jornadas
/// </summary>
public static class JornadaMapper
{
    /// <summary>
    /// Creates a Jornada from a Jornada Model
    /// </summary>
    /// <param name="jornadaModel"></param>
    /// <returns></returns>
    public static Jornada ToEntity(this JornadaModel jornadaModel)
    {
        return new Jornada
        {
            Id = Guid.NewGuid(),
            FriendlyName = jornadaModel.FriendlyName,
            Players = jornadaModel.Players.Select(PlayerMapper.ToEntity)
        };
    }

    /// <summary>
    /// Creates a Jornada Model from a Jornada and generates a new ID
    /// </summary>
    /// <param name="jornada"></param>
    /// <returns></returns>
    public static JornadaModel ToModel(this Jornada jornada)
    {
        return new JornadaModel
        {
            FriendlyName = jornada.FriendlyName,
            Players = jornada.Players.Select(PlayerMapper.ToModel)
        };
    }
}