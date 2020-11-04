using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Unit
    {
        private float dashRange;
        private float dashSpeed;
        private Vector2 projectileSpeed;
        private bool rangeAttack;
        private bool dashAttack;
        private BoostItem[] boostList;

        // Body claculations
        private bool spaceHeldDown = false;

        private void Handleinput()
        {
            //Resets velocity
            //Makes sure that we will stop moving
            //when no keys are pressed
            velocity = Vector2.Zero;

            // Get the current keyboard state
            KeyboardState keyState = Keyboard.GetState();

            //if we press W
            if (keyState.IsKeyDown(Keys.W))
            {
                //jump
                //velocity += new Vector2(0, -1);
            }

            //if we press A
            if (keyState.IsKeyDown(Keys.A))
            {
                //move left
                velocity += new Vector2(-1, 0);
            }

            //if we press D
            if (keyState.IsKeyDown(Keys.D))
            {
                //move right
                velocity += new Vector2(1, 0);
            }
            
            //if we press Space
            if(keyState.Iskeydown(Keys.Space))
            {
                //jump - shouldn't be able to "fly"
                if (!spaceHeldDown && Velocity.Y <= 100f && Velocity.Y >= 0f)
                    Velocity += new Vector2(0f, -1500f);
                spaceHeldDown = true;
            }
            else
                spaceHeldDown = false;

            //If pressed key, then we need to normalize the vector
            //If we don't do this we will move faster
            //while pressing two keys at once
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }

        private void Jump()
        {

        }

        private void Dash()
        {

        }

        private void Collect()
        {

        }

        private void CameraMovement()
        {

        }

        private void RecieveEffect(Pickup pickup)
        {

        }

        public void CheckBoostitem(BoostItem boostItem)
        {

        }

        private void RemoveBoost(BoostItem boostItem)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            //places player closer to the middle
            this.position = new Vector2(GameWorld.GetScreenSize.X / 2, GameWorld.GetScreenSize.Y - sprite.Height / 2);
            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }



        public override void Update(GameTime gameTime)
        {

        }

        public override void OnCollision(GameObject other)
        {

        }
    }
}
