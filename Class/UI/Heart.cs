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
        private bool scaling = true;


        public Heart(Vector2 Position, float scale) : base(Position)
        {
            _scale = scale;
            color = Color.White;
            origin = new Vector2(512, 512);
        }

        public override void Update(GameTime gameTime)
        {
            // Scaling/Pumping Animation for Hearts
            if (scaling == true)
            {
                _scale += 0.001f;

                if (_scale >= 0.08f)
                {
                    scaling = false;
                }
            }

            if (scaling == false)
            {
                _scale -= 0.001f;

                if (_scale <= 0.05f)
                {
                    scaling = true;
                }
            }
        }

        public void RemoveHeart()
        {
            GameManager.RemoveObject(this);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Hearth");
        }
    }
}
