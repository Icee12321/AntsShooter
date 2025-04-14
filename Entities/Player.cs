using System.Numerics;
using AntsShooter.Systems;
using Raylib_cs;

namespace AntsShooter.Entities;

public class Player : Entity
{
    private Vector2 velocity;
    private const float speed = 50f;
    private const float friction = 0.1f;
    private const float maxSpeed = 5f;
    private int facing = 1;

    private const float jumpSpeed = 20f;
    private bool isJumping = false;
    private bool isFalling = false;
    private const float gravity = 50f;
    private const int jumpHight = 2;

    public Player() : base()
    {
        position = new Vector2(Globals.SCREEN_WIDTH/2, Globals.SCREEN_HEIGHT/2);
        
        velocity = Vector2.Zero;
    }
    
    public void HandelMovement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.D) && position.X < Globals.MAP_WIDTH)
        {
            velocity.X += speed * Raylib.GetFrameTime();
            if (velocity.X > maxSpeed) velocity.X = maxSpeed;
            facing = 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.A) && position.X > 0)
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
        
        Console.WriteLine(isJumping);
    }
    
    public void HandleJump()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.W) && !isJumping && !isFalling)
        {
            isJumping = true;
            velocity.Y = -jumpSpeed; // start upward velocity
        }

        if (isJumping)
        {
            if (position.Y <= Globals.originPlayerPos.Y - 1)
            {
                isJumping = false;
                isFalling = true;
            }
        }

        if (isFalling)
        {
            velocity.Y += gravity * Raylib.GetFrameTime();

            if (position.Y >= Globals.originPlayerPos.Y)
            {
                position.Y = Globals.originPlayerPos.Y;
                velocity.Y = 0;
                isFalling = false;
            }
        }
    }
    
    public override void Update()
    {
        base.Update();
        
        HandelMovement();
        HandleJump();

        position += velocity;
        // Console.WriteLine( "X: " + position.X + ", Y: " + position.Y);
    }
    
    public override void Draw()
    {
        base.Draw();

        if (facing == 1)
        {
            Raylib.DrawRectangle((int)MathF.Round(position.X), (int)MathF.Round(position.Y), width, height, Color.Red);
        }
        else
        {
            Raylib.DrawRectangle((int)MathF.Round(position.X), (int)MathF.Round(position.Y), width, height, Color.Red);
            // draw the flipped version of the texture
        }
    }
}