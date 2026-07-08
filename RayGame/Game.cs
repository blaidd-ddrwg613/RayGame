using System.Numerics;
using RayEngine;
using RayEngine.Graphics;
using Raylib_cs;

namespace RayGame;

public class Game() : App(800, 600, "Hello Window", false)
{

    private AnimatedSprite _player;
    private Vector2 _playerPos = new Vector2(100, 100);
    private float _speed = 0.3f;


    public override void InitializeApp()
    {
        
        base.InitializeApp();
    }

    public override void LoadContent()
    {
        TextureAtlas atlas = TextureAtlas.FromFile("spritesheet");
        _player = atlas.CreateAnimatedSprite("player_animation");
        _player.Scale = 4.0f;
        
        base.LoadContent();
    }

    public override void Update(float dt)
    {
        _player.Update(dt);
        
        CheckInput();
        
        base.Update(dt);
    }

    public override void Draw(float dt)
    {
        Raylib.ClearBackground(Color.Black);
        
        _player.Draw(_playerPos);
        
        base.Draw(dt);
    }

    public override void CloseApp()
    {
        base.CloseApp();
    }

    private void CheckInput()
    {
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            _playerPos.Y -= _speed * DeltaTime;
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            _playerPos.X -= _speed * DeltaTime;
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            _playerPos.Y += _speed * DeltaTime;
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            _playerPos.X += _speed * DeltaTime;
        }
    }
}