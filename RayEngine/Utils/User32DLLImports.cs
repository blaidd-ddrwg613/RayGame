using System.Runtime.InteropServices;

namespace RayEngine.Utils;

public class User32DllImports
{
    /// <summary>
    /// Retrieves the specified system metric or system configuration setting.
    /// </summary>
    /// <param name="nIndex">The system metric or configuration setting to be retrieved. Can use an (int)SystemMeticsIndex.
    /// see https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics for more index values </param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int nIndex);
}

/// <summary>
/// Index Values for GetSystemMetrics().
/// Must cast to int (int)SystemMetricsIndex.ScreenWidth
/// </summary>
public enum SystemMetricsIndex
{
    ScreenWidth = 0,
    ScreenHeight = 1
}