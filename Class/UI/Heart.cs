using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.UI
{
    class Heart : UIManager
    {
        public Heart(Vector2 Position, float scale) : base(Position)
        {
            _scale = scale;
            color = Color.White;
            origin = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Hearth");
        }
    }
}
