using System.Numerics;
using MarketRPG.Systems;
using Raylib_cs;

namespace MarketRPG.Entities;

public class Player : Entity
{
    private Vector2 velocity;
    private const float speed = 50f;
    private const float friction = 0.1f;
    private const float maxSpeed = 5f;
    private int facing = 1;

    public Player() : base()
    {
        position = new Vector2(Globals.SCREEN_WIDTH/2, Globals.SCREEN_HEIGHT/2);
        
        velocity = Vector2.Zero;
    }
    
    public override void Update()
    {
        base.Update();

        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            velocity.X += speed * Raylib.GetFrameTime();
            if (velocity.X > maxSpeed) velocity.X = maxSpeed;
            facing = 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            velocity.X -= speed * Raylib.GetFrameTime();
            if (velocity.X < -maxSpeed) velocity.X = -maxSpeed;
            facing = 0;
        }
        else
        {
            if (Math.Abs(velocity.X) > 10)
            {
                velocity.X -= Math.Sign(velocity.X) * friction * Raylib.GetFrameTime();
            }
            else
            {
                velocity.X = 0;
            }
        }

        position += velocity;

        Console.WriteLine(facing);
    }
    
    public override void Draw()
    {
        base.Draw();

        if (facing == 1)
        {
            Raylib.DrawRectangle((int)MathF.Round(position.X), (int)MathF.Round(position.Y), 50, 50, Color.Red);
        }
        else 
        {
            Raylib.DrawRectangle((int)MathF.Round(position.X), (int)MathF.Round(position.Y), 50, 50, Color.Red);
            // draw the flipped version of the texture
        }
    }
}