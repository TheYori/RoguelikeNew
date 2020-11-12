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
        private float timeElapsed;
        private int animationProgress = 0;
        private float fps = 500;
        //private sprites

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
            //sprite = content.Load<Texture2D>("weaponRight");

            //Instantiates the sprite array
            sprites = new Texture2D[6];

            //Loads all sprites into the array
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("Weapon" + (i + 1).ToString());
            }
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            AnimateE(gameTime);
            if(animationProgress == sprites.Length - 1)
            {
                GameManager.RemoveObject(this);
            }
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
        protected void AnimateE(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationProgress = (int)(timeElapsed * 10f);
            if (animationProgress > sprites.Length - 1)
            {
                timeElapsed = 0;
                animationProgress = 0;
            }
            sprite = sprites[animationProgress];

            if(animationProgress == sprites.Length -1)
            { //GameManager.RemoveObject(this);
            }

        }
    }
}
