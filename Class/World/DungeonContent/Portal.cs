using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World.DungeonContent
{
    class Portal : Environment
    {

        bool portalActive = true;

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

            if (gameObject is Player && portalActive)
            {

                //color = Color.Red;
                //levelProgress++;
                //portalActive =false;
                //RemoveObject(this);
                portalActive = false;
                GameManager.RemoveObject(this);
                GameManager.ChangeLevel(2);
            }



        }

    }
}
