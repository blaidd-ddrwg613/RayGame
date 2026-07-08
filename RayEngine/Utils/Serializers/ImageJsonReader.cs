using System.Text.Json;

namespace RayEngine.Serializers;

public class ImageJsonReader
{
    public static JsonImageData ParseJson(string filePath)
    {
        var jsonPath = Path.Combine(App.ResourcePath, "Textures", filePath + ".json");
        string jsonString = File.ReadAllText(jsonPath);
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<JsonImageData>(jsonString, options)!;
    }
}