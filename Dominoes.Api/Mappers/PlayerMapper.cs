using Dominoes.Api.Models;
using Dominoes.Core;

namespace Dominoes.Api.Mappers;

/// <summary>
/// Static class that handles Player mapping
/// </summary>
public static class PlayerMapper
{
    /// <summary>
    /// Creates a new Player given a player model and assign a new ID
    /// </summary>
    /// <param name="playerModel"></param>
    /// <returns></returns>
    public static Player ToEntity(this PlayerModel playerModel)
    {
        return new Player
        {
            Id = Guid.NewGuid(),
            Name = playerModel.Name,
            Encounters = playerModel.Encounters.Select(EncounterMapper.ToEntity)
        };
    }
    
    /// <summary>
    /// Creates a new Player model given a player
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static PlayerModel ToModel(this Player player)
    {
        return new PlayerModel
        {
            Name = player.Name,
            Encounters = player.Encounters.Select(EncounterMapper.ToModel)
        };
    }
}