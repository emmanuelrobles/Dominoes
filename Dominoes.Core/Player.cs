using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominoes.Core;

public class Player
{
    /// <summary>
    /// Players Id
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Players Name
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// List of encounters played by this player
    /// </summary>
    public IEnumerable<Encounter> Encounters { get; init; } = Enumerable.Empty<Encounter>();
}