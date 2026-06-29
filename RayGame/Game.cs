using System.Numerics;
using RayEngine;
using RayEngine.Graphics;
using Raylib_cs;

namespace RayGame;

public class Game() : App(800, 600, "Hello Window", false)
{

    private TextureRegion _player;
    public override void InitializeApp()
    {
        base.InitializeApp();
    }

    public override void LoadContent()
    {
        Texture2D atlasTexture = Raylib.LoadTexture(Path.Combine(ResourcePath, "Textures", "player.png"));
        TextureAtlas atlas = new TextureAtlas(atlasTexture);
        atlas.AddRegion("player",0, 0, 16, 16);
        _player = atlas.GetRegion("player");
        
        base.LoadContent();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.Black);
        
        _player.Draw(new Vector2(100, 100));
        
        base.Draw();
    }

    public override void CloseApp()
    {
        base.CloseApp();
    }
}