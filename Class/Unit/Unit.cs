using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
    public class Unit : GameObject
    {
        protected Vector2 velocity;
        protected float speed;

        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (velocity.Length() != 0)
            {

                position += ((velocity * speed) * deltaTime);

            }
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void OnCollision(GameObject gameObject)
        {
          
        }

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
