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
        protected Vector2 position;
        protected Rectangle collisionBox;

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);

        public abstract void onCollision(GameObject gameObject);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, 0, origin, 1, SpriteEffects.None, 0);
        }

        public bool CheckCollision(GameObject obj)
        {
            if (collisionBox.Intersects(obj.collisionBox))
            {
                onCollision(obj);
                return true;
            }

            return false;
        }
    }
    
}
