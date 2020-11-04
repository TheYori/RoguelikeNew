using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World
{
    class Environment : GameObject
    {

        public Environment(Vector2 Position)
        {
            base.position = position;
            color = Color.White;
            origin = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("platFormDummyNormalSize");

        }

        public override void onCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
