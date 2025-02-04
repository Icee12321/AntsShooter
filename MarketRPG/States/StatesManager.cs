using MarketRPG.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarketRPG.States
{
    internal class StatesManager
    {
        private static PlayState playState = new PlayState();
        private static MenuState menuState = new MenuState();

        public static string currentState = "playState";

        internal static void LoadContent(ContentManager Content)
        {
            switch (currentState)
            {
                case "minuState":
                    menuState.LoadContent(Content);
                    break;
                case "playState":
                    playState.LoadContent(Content);
                    break;
            }
        }

        internal static void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case "minuState":
                    menuState.Update(gameTime);
                    break;
                case "playState":
                    playState.Update(gameTime);
                    break;
            }
        }

        internal static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (currentState)
            {
                case "minuState":
                    menuState.Draw(spriteBatch, gameTime);
                    break;
                case "playState":
                    playState.Draw(spriteBatch, gameTime);
                    break;
            }
        }
    }
}
