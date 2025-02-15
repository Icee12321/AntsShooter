using System.Numerics;
using System.Runtime.CompilerServices;
using MarketRPG.Entities;
using MarketRPG.Systems;
using Raylib_cs;

namespace MarketRPG.States;

public class PlayState : IState
{
    private Player player;
    Camera2D camera;
    Vector2 testBlockPosition;

    
    public PlayState()
    {
        player = new Player();
        LoadCamera();

        testBlockPosition =  new Vector2(0, 0);
    }
    
    public void Update()
    {
        player.Update();
        UpdateCamera();
    }

    public void Draw()
    {
        Raylib.BeginMode2D(camera);
        player.Draw();

        Raylib.DrawRectangle((int)MathF.Round(testBlockPosition.X), (int)MathF.Round(testBlockPosition.Y), 50, 50, Color.Blue);       
        Raylib.EndMode2D();
    }

    private void LoadCamera()
    {
        camera = new Camera2D();
        camera.Target = player.position;
        camera.Offset = new Vector2(Globals.SCREEN_WIDTH/2 - 25, Globals.SCREEN_HEIGHT/2); 
        camera.Rotation = 0.0f;
        camera.Zoom = 1.0f;
    }

    private void UpdateCamera()
    {
        camera.Target = Vector2.Lerp(camera.Target, player.position, 0.1f); 
    }
}