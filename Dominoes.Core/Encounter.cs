using System;

namespace Dominoes.Core;

public class Encounter
{

    /// <summary>
    /// Encounter Guid
    /// </summary>
    public Guid Id { get; init; }
    
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