﻿using AntsShooter.Systems;
using Raylib_cs;

namespace AntsShooter;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(Globals.SCREEN_WIDTH, Globals.SCREEN_HEIGHT, "AntsShooter");
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
