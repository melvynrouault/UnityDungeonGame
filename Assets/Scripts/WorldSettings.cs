public sealed class WorldSettings 
{
    private WorldSettings() { }

    private static WorldSettings _instance;

    public static WorldSettings Instance => _instance ?? (_instance = new WorldSettings());

    public Level Level { get; set; }

    public static float getMultiplicator()
    {
        var multiplicatror = 1f;
        
        switch (Instance.Level)
        {
            case Level.Easy:
                multiplicatror = 1f;
                break;
            case Level.Medium:
                multiplicatror = 1.5f;
                break;
            case Level.Hard:
                multiplicatror = 2f;
                break;
        }

        return multiplicatror;
    }
}
