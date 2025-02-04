using System.Diagnostics;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using MarketRPG.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarketRPG.Entitys
{
    internal class Player : Entity
    {
        public Player() : base()
        {
            
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
