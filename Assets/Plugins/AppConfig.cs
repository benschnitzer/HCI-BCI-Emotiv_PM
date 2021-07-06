/// <summary>
/// Contain configuration of a specific App.
/// </summary>
static class AppConfig
{
    public static string AppUrl              = "wss://localhost:6868";
    public static string AppName             = "UnityApp";
    
    /// <summary>
    /// Name of directory where contain tmp data and logs file.
    /// </summary>
    public static string TmpAppDataDir       = "UnityApp";
    public static string ClientId            = "5MWedMJgz5NEYqAmR8zpB5Ar5C2fKkXsAFY4GTMG";
    public static string ClientSecret        = "GE40OrCwOtXKpnIqaSUIKkS8vos43yjML0zF3m1XhmYpwwZfTKQ42wGHTLAQquB3ykLL5v8VGS4ExnjsiW6qPS1xN1Dk1CXjanQcKL4esusHk4ckkw7mocNTkWIQ6Ztq";
    public static string AppVersion          = "2.7.0 Dev";
    
    /// <summary>
    /// License Id is used for App
    /// In most cases, you don't need to specify the license id. Cortex will find the appropriate license based on the client id
    /// </summary>
    public static string AppLicenseId        = "";
    //public static string AppLicenseId = "a14fe794-8876-49ba-a5df-2d2cf042694a";
}