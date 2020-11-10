using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Class;
using Roguelike.Class.World;
using Roguelike.Class.World.DungeonContent;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;



namespace Roguelike
{
    class Player : Unit
    {
        // Fields for Dash ability
        private float dashRange;
        private float dashSpeed;
        private bool dashAttack;

        // Fields for long range attack
        private Vector2 projectileSpeed;
        private bool rangeAttack;
        
        private BoostItem[] boostList;

        // Fields for movements
        bool keyHeldDown;

        public Player()
        {
            color = Color.White; //Racist Motherf*cker!
            fps = 6;
            speed = 500f;
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            ApplyPhysics(gameTime);
            Move(gameTime);
            Animate(gameTime);

            ScreenWarp();
            ScreenLimits();
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

        /// <summary>
        /// Applies physics such as gravity and velocity.
        /// </summary>
        private void ApplyPhysics(GameTime gameTime)
        {
            //Applies gravity
            velocity += new Vector2(0f, 0.05f);
        }  

        private void HandleInput()
        {
            //Resets velocity
            //Makes sure that we will stop moving
            //when no keys are pressed
            velocity = new Vector2(0f, velocity.Y);

            // Get the current keyboard state
            KeyboardState keyState = Keyboard.GetState();

            //if we press W
            if (keyState.IsKeyDown(Keys.W))
            {
                // Allows the player to go up, but 
                //stops the player to continue to do so, bu holding the key.
                if (!keyHeldDown)
                    velocity = new Vector2(velocity.X, -1);
                    keyHeldDown = true;
            }
            else
                keyHeldDown = false;

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

            if (keyState.IsKeyDown(Keys.Space))
            {
                //ADD attack
            }
        }

        public override void Initialize()
        {

        }

        private void Jump()
        {

        }   //QUESTION: do we need the jump function to have its own method?

        private void Dash()
        {

        }  //"Dash" is technically a movement, but since we need to [manipulate] it, "Dash" have its own method

        private void Collect()
        {

        }

        private void CameraMovement()
        {

        } 

        private void RecieveEffect(PickUp pickup)
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

            //spawns the player in the left buttom corner
            //Somehow makes a ground collision on the bottom of the screen
            //Remove these to lines of code IF player have to spawn elsewhere or need a proper ground to stand on
            this.position = new Vector2(GameManager.GetScreenSize.X - GameManager.GetScreenSize.X + sprite.Width / 2, GameManager.GetScreenSize.Y - sprite.Height / 2); 
            this.origin = new Vector2(sprite.Width / 2, sprite.Height);
        }

        // Makes collisionBox visible for the player sprite
        public override void OnCollision(GameObject gameObject)
        {
            this.offset = new Vector2(sprite.Width / -2, sprite.Height * -1); //Centers the Collison box
        }
    }
}

