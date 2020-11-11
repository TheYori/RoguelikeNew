using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Class;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class MeleeWeapon : GameObject
    {
        private bool isWeaponRight;


        public MeleeWeapon(Vector2 position)
        {
            this.position = position;
            color = Color.White;
            origin = Vector2.Zero;

        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            //Loads melee weapon
            sprite = content.Load<Texture2D>("weaponRight");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();


            //if(KeyboardState.GetState().IsKeyDown(Keys.A))
            //{

            //}


            if(isWeaponRight == false)
            {
                base.effects = SpriteEffects.None;
            }
         
            if(isWeaponRight == true)
            {
                base.effects = s;
            }

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
