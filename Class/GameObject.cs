using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
    public abstract class GameObject : GameManager
    {
        protected Texture2D sprite;
        protected Vector2 origin;
        protected Color color;

        public abstract void LoadContent(ContentManager content);      

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, 0, origin, 1, SpriteEffects.None, 0);
        }
    }
}
