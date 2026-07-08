using RayEngine.Serializers;

namespace RayEngine.Graphics;

using Raylib_cs;

public class TextureAtlas
{
    private Dictionary<string, TextureRegion> _regions;

    private Dictionary<string, Animation> _animations;
    
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
        _animations = new Dictionary<string, Animation>();
    }

    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        _regions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string, Animation>();
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
    /// Adds the given animation to this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to add.</param>
    /// <param name="animation">The animation to add.</param>
    public void AddAnimation(string animationName, Animation animation)
    {
        _animations.Add(animationName, animation);
    }

    /// <summary>
    /// Gets the animation from this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to retrieve.</param>
    /// <returns>The animation with the specified name.</returns>
    public Animation GetAnimation(string animationName)
    {
        return _animations[animationName];
    }

    /// <summary>
    /// Removes the animation with the specified name from this texture atlas.
    /// </summary>
    /// <param name="animationName">The name of the animation to remove.</param>
    /// <returns>true if the animation is removed successfully; otherwise, false.</returns>
    public bool RemoveAnimation(string animationName)
    {
        return _animations.Remove(animationName);
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

        JsonImageData data = ImageJsonReader.ParseJson(fileName);

        var texturePath = Path.Combine(App.ResourcePath, "Textures", data.ImageData.Texture);
        atlas.Texture = Raylib.LoadTexture(texturePath);

        foreach (var frame in data.Frames)
        {
            // Frame Data
            var frameData = frame.Value;
            string? name = frame.Key;
            int x = frameData.X;
            int y = frameData.Y;
            int width = frameData.Width;
            int height = frameData.Height;
            
            if (!string.IsNullOrEmpty(name))
            {
                atlas.AddRegion(name, x, y, width, height);
            }
            else
            {
                Raylib.TraceLog(TraceLogLevel.Error, "Frame name is Null or Empty");
            }
        }
        
        // Animation Data

        foreach (var animationData in data.AnimationData)
        {
            var animValues = animationData.Value;

            string name = animationData.Key;
            TimeSpan delay = TimeSpan.FromMilliseconds(animValues.Delay);

            List<TextureRegion> frames = new List<TextureRegion>();

            foreach (var frameElement in animValues.Frames)
            {
                TextureRegion region = atlas.GetRegion(frameElement);
                frames.Add(region);
            }

            Animation animation = new Animation(frames, delay);
            atlas.AddAnimation(name, animation);
        }
        
        return atlas;
    }

    public Sprite CreateSprite(string name)
    {
        TextureRegion region = GetRegion(name);
        return new Sprite(region);
    }
    
    /// <summary>
    /// Creates a new animated sprite using the animation from this texture atlas with the specified name.
    /// </summary>
    /// <param name="animationName">The name of the animation to use.</param>
    /// <returns>A new AnimatedSprite using the animation with the specified name.</returns>
    public AnimatedSprite CreateAnimatedSprite(string animationName)
    {
        Animation animation = GetAnimation(animationName);
        return new AnimatedSprite(animation);
    }
}