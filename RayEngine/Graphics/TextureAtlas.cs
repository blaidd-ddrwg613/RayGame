using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using RayEngine.Serializers;

namespace RayEngine.Graphics;

using Raylib_cs;

public class TextureAtlas
{
    private Dictionary<string, TextureRegion> _regions;
    
    /// <summary>
    /// Gets or Sets the source texture represented by this texture atlas.
    /// </summary>
    public Texture2D Texture { get; set; }

    /// <summary>
    /// Creates a new texture atlas
    /// </summary>
    public TextureAtlas()
    {
        _regions = new Dictionary<string, TextureRegion>();
    }

    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        _regions = new Dictionary<string, TextureRegion>();
    }

    /// <summary>
    /// Creates a new region and adds it to this texture atlas.
    /// </summary>
    /// <param name="name">The name to give the texture region.</param>
    /// <param name="x">The top-left x-coordinate position of the region boundary relative to the top-left corner of the source texture boundary.</param>
    /// <param name="y">The top-left y-coordinate position of the region boundary relative to the top-left corner of the source texture boundary.</param>
    /// <param name="width">The width, in pixels, of the region.</param>
    /// <param name="height">The height, in pixels, of the region.</param>
    public void AddRegion(string name, int x, int y, int width, int height)
    {
        TextureRegion region = new TextureRegion(Texture, x, y, width, height);
        _regions.Add(name, region);
    }

    /// <summary>
    /// Gets the region from this texture atlas with the specified name.
    /// </summary>
    /// <param name="name">The name of the region to retrieve.</param>
    /// <returns>The TextureRegion with the specified name.</returns>
    public TextureRegion GetRegion(string name)
    {
        return _regions[name];
    }

    /// <summary>
    /// Removes the region from this texture atlas with the specified name.
    /// </summary>
    /// <param name="name">The name of the region to remove.</param>
    /// <returns></returns>
    public void RemoveRegion(string name)
    {
        _regions.Remove(name);
    }

    /// <summary>
    /// Removes all regions from this texture atlas.
    /// </summary>
    public void Clear()
    {
        _regions.Clear();
    }
    
    /// <summary>
    /// Creates a new texture atlas based on a texture atlas XML configuration file.
    /// </summary>
    /// <param name="content">The content manager used to load the texture for the atlas.</param>
    /// <param name="fileName">The path to the Aseprite JSON file, relative to the content root directory.</param>
    /// <returns>The texture atlas created by this method.</returns>
    public static TextureAtlas FromFile(string fileName)
    {
        TextureAtlas atlas = new TextureAtlas();

        AsepriteData data = AsepriteJsonReader.ParseJson(fileName);

        var texturePath = Path.Combine(App.ResourcePath, "Textures", data.Meta.Image);
        atlas.Texture = Raylib.LoadTexture(texturePath);

        foreach (var frame in data.Frames)
        {
            var frameData = frame.Value;
            string? name = frame.Key;
            int x = frameData.Frame.X;
            int y = frameData.Frame.Y;
            int width = frameData.Frame.W;
            int height = frameData.Frame.H;
            
            if (!string.IsNullOrEmpty(name))
            {
                atlas.AddRegion(name, x, y, width, height);
            }
            else
            {
                Raylib.TraceLog(TraceLogLevel.Error, "Frame name is Null or Empty");
            }
        }
        return atlas;
    }

    public Sprite CreateSprite(string name)
    {
        TextureRegion region = GetRegion(name);
        return new Sprite(region);
    }
}