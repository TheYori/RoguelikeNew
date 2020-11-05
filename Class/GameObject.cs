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

        protected Texture2D[] sprites;
        protected float speed;
        protected Vector2 velocity;
        protected Vector2 offset;
        protected float fps;
        private float timeElapsed;
        private int currentIndex;

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);

        public abstract void onCollision(GameObject gameObject);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null , color, 0, origin, 1, SpriteEffects.None, 0);
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

        //Needed to add to make a somewhat working player
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                (int)(position.X + offset.X),
                (int)(position.Y + offset.Y),
                sprite.Width,
                sprite.Height);
            }
        }

        protected void Animate(GameTime gameTime)
        {
            //Adds time that has passed since last update
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Calculates the current index
            currentIndex = (int)(timeElapsed * fps);

            sprite = sprites[currentIndex];

            //Checks if we need to restart the animation
            if (currentIndex >= sprites.Length - 1)
            {
                //Resets the animation
                timeElapsed = 0;
                currentIndex = 0;
            }
        }

        protected void Move(GameTime gameTime)
        {
            //Calculates deltaTime based on...
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Moves the object based on the result from HandleInput, speed and deltatime
            position += ((velocity * speed) * deltaTime);
        }
    }

}
