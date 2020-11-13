using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World.DungeonContent
{
    public class Portal : Environment
    {

        private Texture2D[] animationPortal = new Texture2D[12];


        public int portalProgress = 0;
        public float fps = 15;
        public float timeElapsed;


        public Portal(Vector2 Position) : base(Position) {
            color = Color.White;
            origin = Vector2.Zero;
            base.sprite = sprite; 
     
        }

        public override void Update(GameTime gameTime)
        {
            AnimatePortal(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("Portal1");

            animationPortal[0] = content.Load<Texture2D>("Portal1");
            animationPortal[1] = content.Load<Texture2D>("Portal2");
            animationPortal[2] = content.Load<Texture2D>("Portal3");
            animationPortal[3] = content.Load<Texture2D>("Portal4");
            animationPortal[4] = content.Load<Texture2D>("Portal5");
            animationPortal[5] = content.Load<Texture2D>("Portal6");
            animationPortal[6] = content.Load<Texture2D>("Portal7");
            animationPortal[7] = content.Load<Texture2D>("Portal8");
            animationPortal[8] = content.Load<Texture2D>("Portal9");
            animationPortal[9] = content.Load<Texture2D>("Portal10");
            animationPortal[10] = content.Load<Texture2D>("Portal11");
            animationPortal[11] = content.Load<Texture2D>("Portal12");

        }


        protected void AnimatePortal(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            portalProgress = (int)(timeElapsed * fps);
            if (portalProgress > animationPortal.Length - 1)
            {
                timeElapsed = 0;
                portalProgress = 0;
            }
            sprite = animationPortal[portalProgress];

        }


        public override void Initialize()
        {

        }

        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Player )
            {

                GameManager.levelProgression++;
                GameManager.RemoveObject(this);
                GameManager.ChangeLevel(GameManager.levelProgression);
            }



        }





    }
}
