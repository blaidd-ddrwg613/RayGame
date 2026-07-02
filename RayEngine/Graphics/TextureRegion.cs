using System.Numerics;
using Raylib_cs;

namespace RayEngine.Graphics;

/// <summary>
/// Represents the individual sprites/images within a larger texture/atlas.
/// </summary>
public class TextureRegion
{
    /// <summary>
    /// Gets or sets the source texture this texture region is part of.
    /// </summary>
    public Texture2D Texture { get; set; }
    
    /// <summary>
    /// Gets or Sets the source rectangle boundary of this texture region within the source texture.
    /// </summary>
    public Rectangle SrcRectangle { get; set; }

    /// <summary>
    /// Gets the width in pixels of this texture region
    /// </summary>
    public float Width => SrcRectangle.Width;

    /// <summary>
    /// Gets the height in pixels of this texture region.
    /// </summary>
    public float Height => SrcRectangle.Height;

    /// <summary>
    /// Creates a new Texture Region.
    /// </summary>
    public TextureRegion() {}

    /// <summary>
    /// Create a new Texture Region using the specified Texture.
    /// </summary>
    /// <param name="texture">The texture used as the source texture for this texture region.</param>
    /// <param name="x">The x-coordinate position of this texture region relative to the source texture.</param>
    /// <param name="y">The y-coordinate position of this texture region relative to the source texture.</param>
    /// <param name="width">The width of the texture region in pixels relative to the source texture.</param>
    /// <param name="height">The height of the texture region in pixels relative to the source texture.</param>
    public TextureRegion(Texture2D texture, float x, float y, int width, int height)
    {
        Texture = texture;
        SrcRectangle = new Rectangle(x, y, width, height);
    }

    /// <summary>
    /// Draws the texture region using default rotation, scale and tint
    /// </summary>
    /// <param name="position">The position to draw this texture region on screen.</param>
    public void Draw(Vector2 position)
    {
        Draw(position, 0.0f, new Vector2(0,0), 1.0f, Color.White);
    }

    /// <summary>
    /// Draws the texture region using default rotation and scale.
    /// </summary>
    /// <param name="position">The position to draw this texture region on screen.</param>
    /// <param name="tint">The tint color to be used when drawing this texture region.</param>
    public void Draw(Vector2 position, Color tint)
    {
        Draw(position,0.0f, new Vector2(0,0), 0.0f ,tint);
    }
    
    /// <summary>
    /// Draws the texture region.
    /// </summary>
    /// <param name="position">The position to draw this texture region on screen.</param>
    /// <param name="rotation">The rotation of the texture region as a float.</param>
    /// <param name="scale">The scale of the texture region scaled both x and y using the float.</param>
    /// <param name="tint">The tint color to be used when drawing this texture region.</param>
    public void Draw(Vector2 position, float rotation, Vector2 origin, float scale, Color tint)
    {
        Rectangle dst = new Rectangle(position, new Vector2(SrcRectangle.Width * scale, SrcRectangle.Height * scale));
        Raylib.DrawTexturePro(Texture, SrcRectangle, dst, origin, rotation, tint);
    }
    
}