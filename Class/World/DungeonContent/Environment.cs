using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
    public class Environment : GameObject
    {


        public Environment(Vector2 MyPosition)
        {
            position = MyPosition;
            color = Color.White;
            origin = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
        


        }

        public override void OnCollision(GameObject gameObject)
        {
            
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
