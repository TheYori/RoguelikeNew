using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
    class Platform : Environment
    {

        public Platform(Vector2 Position):base(Position){
            color = Color.White;
            origin = Vector2.Zero;
        

        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {

           sprite = content.Load<Texture2D>("platFormDummyLargeSize");


        }

        public override void OnCollision(GameObject gameObject)
        {
            if(gameObject is Player)
            {
          

                if (position.Y - sprite.Height > gameObject.position.Y - gameObject.sprite.Height && gameObject.velocity.Y > 0f)
                {
           

                  
                    gameObject.velocity = new Vector2(gameObject.velocity.X, 0f);
                    gameObject.position = new Vector2(gameObject.position.X, CollisionBox.Top);
                

                }
            }

            base.OnCollision(gameObject);
        }

    }
}
