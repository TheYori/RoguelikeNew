using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.UI
{
    class Counter : UIManager
    {
        private bool rotating = true;
        public Counter(Vector2 Position, float scale, float rotation) : base(Position)
        {
            _scale = scale;
            color = Color.White;
            origin = new Vector2(256, 256);
            _rotation = rotation;
        }

        public override void Update(GameTime gameTime)
        {
            // Rotation Animation for Counter
            if (rotating == true)
            {
                base._rotation += 0.001f;

                if (base._rotation >= 0.09f)
                {
                    rotating = false;
                }
            }

            if (rotating == false)
            {
                base._rotation -= 0.001f;

                if (base._rotation <= 0.01f)
                {
                    rotating = true;
                }
            }
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("MonsterIcon");
        }
    }
}
