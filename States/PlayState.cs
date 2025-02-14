using MarketRPG.Entities;
using Raylib_cs;

namespace MarketRPG.States;

public class PlayState : IState
{
    private Player player;
    
    public PlayState()
    {
        player = new Player();
    }
    
    public void Update()
    {
        player.Update();
    }

    public void Draw()
    {
        player.Draw();
    }
}