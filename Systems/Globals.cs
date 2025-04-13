using System.Collections.Specialized;
using System.Numerics;
using Raylib_cs;

namespace AntsShooter.Systems;

public class Globals
{
    public const int SCREEN_WIDTH = 1067;
    public const int SCREEN_HEIGHT = 600;

    public static Vector2 originPlayerPos = new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2);
}