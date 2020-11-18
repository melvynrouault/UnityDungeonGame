public sealed class WorldSettings 
{
    private WorldSettings() { }

    private static WorldSettings _instance;

    public static WorldSettings Instance => _instance ?? (_instance = new WorldSettings());

    public Level Level { get; set; }
}
