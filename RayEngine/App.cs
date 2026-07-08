using RayEngine.Utils;
using Raylib_cs;

namespace RayEngine;

public class App :IDisposable
{
    internal static App? s_instance;
    
    /// <summary>
    /// The Width of the Window.
    /// </summary>
    public static int WindowWidth { get; set; }
    
    /// <summary>
    /// The Height of the Window
    /// </summary>
    public static int WindowHeight { get; set; }
    
    /// <summary>
    /// The Title of the Window.
    /// </summary>
    public static string WindowTitle { get; set; }

    public static TimeSpan DeltaTime { get; set; }
    
    /// <summary>
    /// If the window is in fullscreen
    /// </summary>
    public static bool IsFullscreen { get; set; }
    
    public static string ResourcePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
    
    public App(int width, int height, string title, bool fullscreen)
    {
        if (s_instance != null)
        {
            throw new InvalidOperationException("Only One App Instance Can Exist at a Time!!");
        }

        // Set the singleton instance
        s_instance = this;
        IsFullscreen = fullscreen;

        DeltaTime = TimeSpan.Zero;
        
        // Set the window Parameters
        if (IsFullscreen)
        {
            WindowWidth = User32DllImports.GetSystemMetrics((int)SystemMetricsIndex.ScreenWidth);
            WindowHeight = User32DllImports.GetSystemMetrics((int)SystemMetricsIndex.ScreenHeight);
        }
        else
        {
            WindowWidth = width;
            WindowHeight = height;
        }
        
        WindowTitle = title;
    }
    
    public void RunGame()
    {
        InitializeApp();
        LoadContent();
        
        while (!Raylib.WindowShouldClose())
        {
            Update(DeltaTime);
            
            Raylib.BeginDrawing();
            Draw(DeltaTime);
            Raylib.EndDrawing();
        }
        
        CloseApp();
    }

    public virtual void InitializeApp()
    {
        Raylib.InitWindow(WindowWidth, WindowHeight, WindowTitle);
    }

    public virtual void LoadContent()
    {
        
    }

    public virtual void Update(TimeSpan dt)
    {
        
    }

    public virtual void Draw(TimeSpan dt)
    {
        DeltaTime = TimeSpan.FromSeconds(Raylib.GetFrameTime());
    }

    public virtual void CloseApp()
    {
        Dispose();
        Raylib.CloseWindow();
    }

    public void Dispose()
    {
        s_instance = null;
    }
}