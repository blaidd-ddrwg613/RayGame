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

    private Sprite _dirt;

    public override void InitializeApp()
    {
        base.InitializeApp();
    }

    public override void LoadContent()
    {
        TextureAtlas atlas = TextureAtlas.FromFile("spritesheet");
        _player = atlas.CreateAnimatedSprite("player_animation");
        _player.Scale = 4.0f;

        // Load ldtk file and store data
        var worldPath = Path.Combine(ResourcePath, "Textures", "world.ldtk");
        var json = File.ReadAllText(worldPath);

        base.LoadContent();
    }

    public override void Update(float dt)
    {
        _player.Update(dt);
        
        CheckInput();
        
        Rectangle screenBounds = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

        if (_playerPos.X <= screenBounds.X)
        {
            _playerPos.X = 0;
        }

        if (_playerPos.X + _player.TextureRegion.Width * _player.Scale  >= screenBounds.Width)
        {
            _playerPos.X = screenBounds.Width - _player.TextureRegion.Width * _player.Scale;
        }

        if (_playerPos.Y <= screenBounds.Y)
        {
            _playerPos.Y = 0;
        }

        if (_playerPos.Y + _player.TextureRegion.Height * _player.Scale >= screenBounds.Height)
        {
            _playerPos.Y = screenBounds.Height - _player.TextureRegion.Height * _player.Scale;
        }
        
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