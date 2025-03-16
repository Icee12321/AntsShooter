using Raylib_cs;
using System.Numerics;

namespace IceLevelEditor
{
    class Button
    {
        public Vector2 position;
        public int width;
        public int height;
        public Color color;


        public Button(Vector2 position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            color = Color.Blue;
        }

        public void Update()
        {
            // not working yet
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(position, new Vector2(width, height))))
            {
                color = Color.SkyBlue;
                Console.WriteLine("hello world");
            }
            else
            {
                color = Color.Blue;
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, width, height, Color.Blue);
        }
    }
}
