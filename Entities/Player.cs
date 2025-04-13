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

    private const float jumpSpeed = 50f;
    private bool isJumping;
    private const float gravity = 50f;
    private const int jumpHight = 50;

    public Player() : base()
    {
        position = new Vector2(Globals.SCREEN_WIDTH/2, Globals.SCREEN_HEIGHT/2);
        
        velocity = Vector2.Zero;
    }
    
    public void HandelMovement()
    {
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
    }
   
    public void HandelJump()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.W))
        {
            isJumping = true;
        }
        
        if (isJumping)
        {
            if (position.Y <= Globals.originPlayerPos.Y - jumpHight)
            {
                isJumping = false;
            }
            else
            {
                velocity.Y -= jumpSpeed * Raylib.GetFrameTime();
            }
        }
        else
        {
            if (position.Y < Globals.originPlayerPos.Y)
            {
                velocity.Y += jumpSpeed * Raylib.GetFrameTime();
                Console.WriteLine(Globals.originPlayerPos);   
            }
            
            if (position.Y >= Globals.originPlayerPos.Y)
            {
                position.Y = Globals.originPlayerPos.Y;
                velocity.Y = 0;
            }
        }
    }
    
    public override void Update()
    {
        base.Update();
        
        HandelMovement();
        HandelJump();

        position += velocity;
        // Console.WriteLine( "X: " + position.X + ", Y: " + position.Y);
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