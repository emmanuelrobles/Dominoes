namespace Dominoes.Api.Models;

/// <summary>
/// Represent a player that is sent by the client
/// </summary>
public class PlayerModel
{
    /// <summary>
    /// Players Name
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// List of encounters played by this player
    /// </summary>
    public IEnumerable<EncounterModel> Encounters { get; init; } = Enumerable.Empty<EncounterModel>();
}