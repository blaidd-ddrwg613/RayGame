using System.Text.Json.Serialization;

namespace RayEngine.Serializers;

public class AsepriteData
{
    [JsonPropertyName("frames")] 
    public Dictionary<string, FrameData> Frames { get; set; }
    
    [JsonPropertyName("meta")]
    public MetaData Meta { get; set; }
}

public class FrameData
{
    [JsonPropertyName("frame")]
    public Rect Frame { get; set; }

    [JsonPropertyName("rotated")]
    public bool Rotated { get; set; }

    [JsonPropertyName("trimmed")]
    public bool Trimmed { get; set; }

    [JsonPropertyName("spriteSourceSize")]
    public Rect SpriteSourceSize { get; set; }

    [JsonPropertyName("sourceSize")]
    public Size SourceSize { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

public class Rect
{
    [JsonPropertyName("x")] public int X { get; set; }
    [JsonPropertyName("y")] public int Y { get; set; }
    [JsonPropertyName("w")] public int W { get; set; }
    [JsonPropertyName("h")] public int H { get; set; }
}

public class Size
{
    [JsonPropertyName("w")] public int W { get; set; }
    [JsonPropertyName("h")] public int H { get; set; }
}

public class MetaData
{
    [JsonPropertyName("app")] public string App { get; set; }
    [JsonPropertyName("version")] public string Version { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
    [JsonPropertyName("format")] public string Format { get; set; }
    [JsonPropertyName("size")] public Size Size { get; set; }
    [JsonPropertyName("scale")] public string Scale { get; set; }
    
    [JsonPropertyName("frameTags")] 
    public List<FrameTag> FrameTags { get; set; }
}

public class FrameTag
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("from")] public int From { get; set; }
    [JsonPropertyName("to")] public int To { get; set; }
    [JsonPropertyName("direction")] public string Direction { get; set; }
    [JsonPropertyName("color")] public string Color { get; set; }
}