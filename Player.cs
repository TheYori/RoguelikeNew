using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
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

        private Texture2D idleSprite;


        public Player()
        {
            fps = 33;
            speed = 800;
            velocity = Vector2.Zero;
        }

        private void ScreenWarp()
        {
            if (position.X > GameManager.GetScreenSize.X + sprite.Width)
            {
                position.X = -sprite.Width;
            }
            else if (position.X < -sprite.Width)
            {
                position.X = GameManager.GetScreenSize.X + sprite.Width;
            }
        }
        private void ScreenLimits()
        {
            if (position.Y - sprite.Height / 2 < 0)
            {
                position.Y = sprite.Height / 2;
            }
            else if (position.Y > GameManager.GetScreenSize.Y)
            {
                position.Y = GameManager.GetScreenSize.Y;
            }
        }

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
            if (keyState.Iskeydown(Keys.Space))
            {
                //ADD attack
            }    
                

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
            //Instantiates the sprite array
            sprites = new Texture2D[2];

            //Loads all sprites into the array
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + "player_walk_Placeholder");
            }

            //Sets a defualt sprite
            sprite = sprites[0];

            //places player closer to the middle
            this.position = new Vector2(GameManager.GetScreenSize.X / 2, GameManager.GetScreenSize.Y - sprite.Height / 2);
            this.origin = new Vector2(sprite.Width / 2, sprite.Height);
        }


        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);

            Animate(gameTime);

            ScreenWarp();
            ScreenLimits();
        }

        
        public override void OnCollision(GameObject other)
        {
            //Makes collisionBox visible for the player sprite
            this.offset = new Vector2(sprite.Width / -2, sprite.Height * -1); //Centers the Collison box
        }
    }
}
