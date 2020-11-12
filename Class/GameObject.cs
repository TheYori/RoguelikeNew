using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
    public abstract class GameObject 
    {
        public Texture2D sprite;
        protected Vector2 origin;
        protected Color color;
        public Vector2 position;


        protected Texture2D[] sprites;
        protected float speed;
        protected float _scale = 1f;
        public Vector2 velocity;
        protected Vector2 offset;
        protected float fps;
        private float timeElapsed;
        private int currentIndex;
        protected SpriteEffects effects = new SpriteEffects();
        protected SpriteEffects s = SpriteEffects.FlipHorizontally;
        protected float alpha = 1f;
        protected float _rotation = 0f;
        public int health;

        private SpriteFont _font;

        protected float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                if (value > 0)
                {
                    alpha = value;
                }
                else
                {
                    alpha = 0;
                }
            }
        }

        public static int levelProgression;

        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        
        public abstract void Update(GameTime gameTime);

        public abstract void OnCollision(GameObject gameObject); 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null , color*Alpha, _rotation, origin, _scale, effects, 0);
            
        } 

        //positions the collisionbox rectangle
        public Rectangle CollisionBox
        {
            get
            {
                //offset X and Y helps center the collison box
                //remove them if player's middle spawn is/will be removed
                return new Rectangle(
                (int)(position.X + offset.X),
                (int)(position.Y + offset.Y),
                sprite.Width,
                sprite.Height);
            }
        } 

        public bool CheckCollision(GameObject obj)
        {
            if (CollisionBox.Intersects(obj.CollisionBox))
            {
                OnCollision(obj);
                return true;
            }

            return false;
        } 

        protected  virtual void Animate(GameTime gameTime)
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
    }
}
