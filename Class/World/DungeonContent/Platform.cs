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

        public override void LoadContent(ContentManager content)
        {

           sprite = content.Load<Texture2D>("platFormDummyNormalSize");


        }
    }
}
