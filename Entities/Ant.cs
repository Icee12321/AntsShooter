using AntsShooter.Systems;
using Raylib_cs;

namespace AntsShooter.Entities;

public class Ant : Entity
{
    private const float speed = 100f;
    private Random random = new Random();
    private int spawnDirection;
    
    public Ant()
    {
        position.Y = Globals.originPlayerPos.Y;
        spawnDirection = random.Next(0, 2); // 0 = left, 1 = right
        if (spawnDirection == 0)
            position.X = 0 - 100;
        else
            position.X = Globals.MAP_WIDTH + 100;
    }

    public void Follow(Player player)
    {
        if (player.position.X - player.width > position.X) // 50 should be the distance between player and ant
        {
            position.X += speed * Raylib.GetFrameTime();
        }
        else if (player.position.X + player.width < position.X)
        {
            position.X -= speed * Raylib.GetFrameTime();
        }
    }

    public override void Update()
    {
        
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)MathF.Round(position.X), (int)MathF.Round(position.Y), 50, 50, Color.Blue);
    }
}