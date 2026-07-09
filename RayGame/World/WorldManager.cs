using RayEngine;

namespace RayGame.World;

public class WorldManager
{
    private RayEngine.World _world;

    public WorldManager(string ldtkWorld)
    {
        var worldPath = Path.Combine(App.ResourcePath, "Textures", ldtkWorld + ".ldtk");
        var jsonData = File.ReadAllText(worldPath);
        _world = RayEngine.World.FromJson(jsonData);
    }

    private void LoadLevelData()
    {
        foreach (var world in _world.Worlds)
        {
            foreach (var level in world.Levels)
            {
                foreach (var layerInstance in level.LayerInstances)
                {
                    foreach (var gridTile in layerInstance.GridTiles)
                    {
                        
                    }
                }
            }
        }
    }
}