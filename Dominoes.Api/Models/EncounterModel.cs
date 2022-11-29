namespace Dominoes.Api.Models;

/// <summary>
/// Represent an Encounter being sent by the client
/// </summary>
public class EncounterModel
{
    /// <summary>
    /// Date when the encounter occured
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// How many games won in that encounter
    /// </summary>
    public ushort Won { get; init; }

    /// <summary>
    /// How many games lost in that encounter
    /// </summary>
    public ushort Lost { get; init; }
}