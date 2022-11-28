namespace Dominoes.Api.Configuration;

/// <summary>
/// Mongo DB configuration
/// </summary>
public class MongoConfig
{
    /// <summary>
    /// Connection string for mongo db
    /// </summary>
    public string ConnectionString { get; init; } = string.Empty;

    /// <summary>
    /// DatabaseName for MongoDb
    /// </summary>
    public string DatabaseName { get; init; } = string.Empty;

    /// <summary>
    /// Collection Name for Jornada Collection
    /// </summary>
    public string JornadaCollectionName { get; init; } = string.Empty;
}