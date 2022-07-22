namespace Velen.Leveling;

// Singleton that stores config data read from the environment file
public class ExperienceConfig
{
    // Private constructor to prevent the instantiation of this singleton.
    private ExperienceConfig()
    {
    }
    
    private static ExperienceConfig _instance;
    private static readonly object Lock = new();
    
    // Thread safe singleton
    public static ExperienceConfig Instance()
    {
        // This conditional is needed to prevent threads stumbling over the
        // lock once the instance is ready.
        if (_instance == null)
        {
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = new ExperienceConfig();
                }
            }
        }
        
        return _instance;
    }
  
    public int ExperienceScale { get; set; }

    // public property that takes a function as an argument to calculate experience lost on respawn
    // public Func<int, int> CalculateRespawnExpLoss { get; set; }
}