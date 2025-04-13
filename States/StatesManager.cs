namespace AntsShooter.States;

public class StatesManager
{
    public static MenuState menuState = new MenuState();
    public static PlayState playState = new PlayState();

    public static string currentState = "PlayState";

    public static void Update()
    {
        switch (currentState)
        {
            case "MenuState":
                menuState.Update();
                break;
            case "PlayState":
                playState.Update();
                break;
        }
    }

    public static void Draw()
    {
        switch (currentState)
        {
            case "MenuState":
                menuState.Draw();
                break;
            case "PlayState":
                playState.Draw();
                break;
        }
    }
}