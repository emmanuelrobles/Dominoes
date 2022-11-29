using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominoes.Core;

public class Jornada
{

    /// <summary>
    /// Unique ID of a jornada
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// A friendly name for a jornada
    /// </summary>
    public string FriendlyName { get; init; } = string.Empty;
        
    /// <summary>
    /// List of players from that jornada
    /// </summary>
    public IEnumerable<Player> Players { get; init; } = Enumerable.Empty<Player>();
}