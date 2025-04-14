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
        private Vector2 cameraTarget;
        private Vector2 testBlockPosition;
        private List<Ant> Ants;
        private float spawnAntTimer = Globals.spawnAntTimer;
        
        public PlayState()
        {
            player = new Player();
            LoadCamera();
            
            Ants = new List<Ant>();
            
            testBlockPosition = new Vector2(0, 0);
        }
        
        private void LoadCamera()
        {
            cameraTarget = new Vector2();
            
            camera = new Camera2D();
            camera.Target = cameraTarget;
            camera.Offset = new Vector2(Globals.SCREEN_WIDTH/2 - player.width/2, Globals.SCREEN_HEIGHT/2 - player.height/2);
            camera.Rotation = 0.0f;
            camera.Zoom = 1.0f;
        }
        
        private void UpdateCamera() 
        {
            cameraTarget.X = player.position.X;
            cameraTarget.Y = Globals.originPlayerPos.Y;
            
            float leftBound = camera.Target.X - camera.Offset.X;
            float rightBound = camera.Target.X + camera.Offset.X;

            if (leftBound < 0) camera.Target.X = camera.Offset.X;
            if (rightBound > Globals.MAP_WIDTH) camera.Target.X = Globals.MAP_WIDTH - camera.Offset.X;
            
            camera.Target = Vector2.Lerp(camera.Target, cameraTarget, 0.1f);
        }

        private void SpawnAnt()
        {
            Ant ant = new Ant();
            Ants.Add(ant);
        }

        private void UpdateAnts()
        {
            if (spawnAntTimer <= 0)
            {
                SpawnAnt();
                spawnAntTimer = Globals.spawnAntTimer;
            }
            else
            {
                spawnAntTimer -= 1 * Raylib.GetFrameTime();   
            }

            foreach (var ant in Ants)
            {
                ant.Follow(player);
            }
        }

        private void DrawAnts()
        {
            foreach (var ant in Ants)
            {
                ant.Draw();
            }
        }

        public void Update()
        {
            player.Update();
            UpdateCamera();
            UpdateAnts();
        }

        public void Draw()
        {
            Raylib.BeginMode2D(camera);
            player.Draw();
            DrawAnts();
            Raylib.DrawRectangle((int)MathF.Round(testBlockPosition.X), (int)MathF.Round(testBlockPosition.Y), 50, 50, Color.Blue);
            Raylib.EndMode2D();
        }
    }
}