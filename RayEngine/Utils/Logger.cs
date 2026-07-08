using Raylib_cs;

namespace RayEngine.Utils;

public class Logger
{
    public static void Log(string msg)
    {
        Raylib.SetTraceLogLevel(TraceLogLevel.All);
        Raylib.TraceLog(TraceLogLevel.All, msg);
        Raylib.SetTraceLogLevel(TraceLogLevel.Info);
    }

    public static void LogTrace(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Trace, msg);
    }

    public static void LogDebug(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Debug, msg);
    }
    
    public static void LogInfo(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Info, msg);
    }
    
    public static void LogWarning(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Warning, msg);
    }

    public static void LogError(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Error, msg);
    }
    
    public static void LogFatal(string msg)
    {
        Raylib.TraceLog(TraceLogLevel.Fatal, msg);
    }
}