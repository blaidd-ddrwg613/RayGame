using System.Numerics;
using System.Text.Json.Serialization;
using RayEngine;
using RayEngine.Graphics;
using Raylib_cs;

namespace RayGame;

public class Game() : App(800, 600, "Hello Window", false)
{

    private Sprite _player;
    private Vector2 _playerPos = new Vector2(100, 100);
    
    
    public override void InitializeApp()
    {
        base.InitializeApp();
    }

    public override void LoadContent()
    {
        Texture2D atlasTexture = Raylib.LoadTexture(Path.Combine(ResourcePath, "Textures", "player.png"));
        TextureAtlas atlas = TextureAtlas.FromFile("player.xml");

        _player = atlas.CreateSprite("player");
        _player.Scale = 4.0f;
        
        base.LoadContent();
        
        
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.Black);
        
        _player.Draw(_playerPos);
        
        base.Draw();
    }

    public override void CloseApp()
    {
        base.CloseApp();
    }
}