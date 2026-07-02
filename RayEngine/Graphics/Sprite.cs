using System.Numerics;
using Raylib_cs;

namespace RayEngine.Graphics;

public class Sprite
{
    /// <summary>
    /// Gets or sets the source texture region represented by this sprite.
    /// </summary>
    public TextureRegion TextureRegion { get; set; }

    /// <summary>
    /// Gets or sets the color used to tint the sprite while drawing.
    /// </summary>
    /// <remarks>
    /// Default value is White.
    /// </remarks>
    public Color Color { get; set; } = Color.White;

    /// <summary>
    /// Gets or set the amount of rotation in radians to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default Value is 0.0f
    /// </remarks>
    public float Rotation { get; set; } = 0.0f;
    
    /// <summary>
    /// Gets or sets the (x,y) scale factor to apply to this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is 1.0f
    /// </remarks>
    public float Scale { get; set; } = 1.0f;

    /// <summary>
    /// Gets or Sets the xy-coordinate origin point, relative to the top-left corner, of this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is Vector2.Zero
    /// </remarks>
    public Vector2 Origin { get; set; } = new Vector2(0, 0);

    /// <summary>
    /// Gets or Sets the layer depth to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is 0.0f
    /// </remarks>
    public float LayerDepth { get; set; } = 0.0f;
    
    public Sprite() {}

    public Sprite(TextureRegion region)
    {
        TextureRegion = region;
    }

    /// <summary>
    /// Sets the origin of this sprite to its center.
    /// </summary>
    public void CenterOrigin()
    {
        Origin = new Vector2(TextureRegion.Width, TextureRegion.Height) * 0.5f;
    }

    public void Draw(Vector2 position)
    {
        TextureRegion.Draw(position, Rotation, Origin, Scale, Color);
    }
}