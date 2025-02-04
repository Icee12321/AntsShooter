using MarketRPG.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarketRPG.Entitys
{
    internal class Entity
    {
        public Vector2 position;
        public Texture2D texture;

        public Entity()
        {
            position = new Vector2(0, 0);
        }

        public virtual void LoadContent(ContentManager Content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }
    }
}
