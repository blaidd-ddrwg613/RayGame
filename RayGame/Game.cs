using System.Numerics;
using RayEngine;
using RayEngine.Graphics;
using RayEngine.Utils;
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
        TextureAtlas atlas = TextureAtlas.FromFile("player");
        _player = atlas.CreateSprite("player_0");
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