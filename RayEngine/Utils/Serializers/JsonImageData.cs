using System.Text.Json.Serialization;

namespace RayEngine.Serializers;

public class JsonImageData
{
    [JsonPropertyName("Regions")] 
    public Dictionary<string, FrameData> Frames { get; set; }
    
    [JsonPropertyName("Image_Data")]
    public ImageData ImageData { get; set; }
    
    [JsonPropertyName("Animations")]
    public Dictionary<string, AnimationData> AnimationData { get; set; }
}

public class FrameData
{
    [JsonPropertyName("x")]
    public int X { get; set; }
    
    [JsonPropertyName("y")]
    public int Y { get; set; }
    
    [JsonPropertyName("Width")]
    public int Width { get; set; }
    
    [JsonPropertyName("Height")]
    public int Height { get; set; }
}

public class ImageData
{
    [JsonPropertyName("texture")]
    public string Texture { get; set; }
}

public class AnimationData
{
    [JsonPropertyName("frames")]
    public List<string> Frames { get; set; }
    
    [JsonPropertyName("delay")]
    public float Delay { get; set; }
}
