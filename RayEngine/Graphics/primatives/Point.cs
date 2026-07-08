using System.Numerics;

namespace RayEngine.Graphics.primatives;

public struct Point
{ 
    public Vector2 Position { get; set; }

    public int X => (int)Position.X;

    public int Y => (int)Position.Y;

    public Point()
    {
        Position = new Vector2();
    }

    public Point(int x, int y)
    {
        Position = new Vector2(x, y);
    }
}