using System.Text.Json;

namespace RayEngine.Serializers;

public class AsepriteJsonReader
{
    public static AsepriteData ParseJson(string filePath)
    {
        var jsonPath = Path.Combine(App.ResourcePath, "Textures", filePath + ".json");
        string jsonString = File.ReadAllText(jsonPath);
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<AsepriteData>(jsonString, options)!;
    }
}