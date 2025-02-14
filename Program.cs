using MarketRPG.Systems;
using Raylib_cs;

namespace MarketRPG;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(Globals.SCREEN_WIDTH, Globals.SCREEN_HEIGHT, "MarketRPG");
        Game game = new Game();
        
        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            game.Update();
            Raylib.ClearBackground(Color.White);
            game.Draw();
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
