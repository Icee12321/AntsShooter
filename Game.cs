using AntsShooter.States;
using AntsShooter.Systems;
using Raylib_cs;


namespace AntsShooter;

public class Game
{

    public Game()
    {
        
    }
    
    public void Update()
    {
        StatesManager.Update();
    }

    public void Draw()
    {
        StatesManager.Draw();
    }
}