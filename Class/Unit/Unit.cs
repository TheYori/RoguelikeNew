using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
   public enum UnitType
    {
        AnEnemy, APlayer, None
    }
    public class Unit : GameObject
    {



        protected int health;

        protected UnitType Type = UnitType.None;
        public int DealDamage(int a)
        {
            return health -= a;
            
        }

   


        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            
            if( Type == UnitType.APlayer)
            {
                if (velocity.Length() != 0)
                {

                    position += ((velocity * speed) * deltaTime);

                }

            }

        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void OnCollision(GameObject gameObject)
        {
          
        }

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
            //-Debug

        }
    }
}
