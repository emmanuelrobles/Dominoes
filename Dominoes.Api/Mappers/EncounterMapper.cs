using Dominoes.Api.Models;
using Dominoes.Core;

namespace Dominoes.Api.Mappers;

/// <summary>
/// Static class that handles encounter mapping
/// </summary>
public static class EncounterMapper
{
    /// <summary>
    /// Convert an encounter model to an encounter and assign a new Id
    /// </summary>
    /// <param name="encounterModel"></param>
    /// <returns>A new Encounter</returns>
    public static Encounter ToEntity(this EncounterModel encounterModel)
    {
        return new Encounter
        {
            Id = Guid.NewGuid(),
            Date = encounterModel.Date,
            Lost = encounterModel.Lost,
            Won = encounterModel.Won
        };
    }
    
    /// <summary>
    /// Convert an encounter to an encounter Model
    /// </summary>
    /// <param name="encounter"></param>
    /// <returns>A new EncounterModel</returns>
    public static EncounterModel ToModel(this Encounter encounter)
    {
        return new EncounterModel
        {
            Date = encounter.Date,
            Lost = encounter.Lost,
            Won = encounter.Won
        };
    }
}