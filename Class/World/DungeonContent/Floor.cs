using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World.DungeonContent
{
    class Floor : Environment
    {
        public Floor(Vector2 Position) : base(Position)
        {

            color = Color.White;
            origin = Vector2.Zero;


        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("Ground");


        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is Unit)
            {

                if (CollisionBox.Bottom > gameObject.CollisionBox.Bottom)
                {
             

                    gameObject.velocity = new Vector2(velocity.X, 0f);

                    gameObject.position = new Vector2(gameObject.position.X, CollisionBox.Top);

                }
            }

            base.OnCollision(gameObject);
        }
    }
}
