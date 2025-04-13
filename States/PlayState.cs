using System.Numerics;
using System.Runtime.CompilerServices;
using AntsShooter.Editor;
using AntsShooter.Entities;
using AntsShooter.Systems;
using Raylib_cs;

namespace AntsShooter.States
{
    public class PlayState : IState
    {
        private Player player;
        private Camera2D camera;
        private Vector2 testBlockPosition;
        private bool editLevel;


        public PlayState()
        {
            player = new Player();
            LoadCamera();
            editLevel = false;

            testBlockPosition = new Vector2(0, 0);
        }

        public void Update()
        {
            player.Update();
            if (editLevel)
            {
                LevelEditor.Update();
            }
            UpdateCamera();
        }

        public void Draw()
        {
            Raylib.BeginMode2D(camera);
            player.Draw();

            Raylib.DrawRectangle((int)MathF.Round(testBlockPosition.X), (int)MathF.Round(testBlockPosition.Y), 50, 50, Color.Blue);
            LevelEditorUpdate();
            Raylib.EndMode2D();
        }

        private void LoadCamera()
        {
            camera = new Camera2D();
            camera.Target = player.position;
            camera.Offset = new Vector2(Globals.SCREEN_WIDTH / 2 - 25, Globals.SCREEN_HEIGHT / 2);
            camera.Rotation = 0.0f;
            camera.Zoom = 1.0f;
        }

        private void UpdateCamera()
        {
            camera.Target = Vector2.Lerp(camera.Target, player.position, 0.1f);
        }

        private void LevelEditorUpdate()
        {
            if (editLevel)
            {
                LevelEditor.Draw();
            }
        }
    }
}