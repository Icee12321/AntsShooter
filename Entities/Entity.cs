using System.Numerics;
using Raylib_cs;

namespace MarketRPG.Entities;

public class Entity
{
    public Vector2 position;
    public Texture2D texture;

    public Entity()
    {
        position = new Vector2(0, 0);
        texture = new Texture2D();
    }

    public virtual void Update()
    {

    }

    public virtual void Draw()
    {
        
    }
}