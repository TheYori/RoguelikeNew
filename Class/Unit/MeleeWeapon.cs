using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Class;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class MeleeWeapon : Player
    {

        public MeleeWeapon(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
            
        }

        public override void LoadContent(ContentManager content)
        {


        }
        public override void Update(GameTime gameTime)
        {
            
        }

        public override void OnCollision(GameObject other)
        {
            this.offset = new Vector2(sprite.Width * -0f, sprite.Height * -0f); //Centers the Collison box

            if (other is Enemy)
            {

            }
        }
    }
}
