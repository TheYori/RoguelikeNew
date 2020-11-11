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

        public Portal(Vector2 Position) : base(Position) {
            color = Color.White;
            origin = Vector2.Zero;
            base.sprite = sprite; 
     
        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("Portal");

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
