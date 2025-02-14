using MarketRPG.States;


namespace MarketRPG;

public class Game
{
    public void Update()
    {
        StatesManager.Update();
    }

    public void Draw()
    {
        StatesManager.Draw();
    }
}