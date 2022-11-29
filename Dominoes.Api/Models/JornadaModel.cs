namespace Dominoes.Api.Models;

/// <summary>
/// Represent a Jornada that is being sent by the client
/// </summary>
public class JornadaModel
{
    /// <summary>
    /// A friendly name for a jornada
    /// </summary>
    public string FriendlyName { get; init; } = string.Empty;
        
    /// <summary>
    /// List of players from that jornada
    /// </summary>
    public IEnumerable<PlayerModel> Players { get; init; } = Enumerable.Empty<PlayerModel>();
}