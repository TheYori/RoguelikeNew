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
        private float dashRange;
        private float dashSpeed;
        private Vector2 projectileSpeed;
        private bool rangeAttack;
        private bool dashAttack;
        private BoostItem[] boostList;
        bool wHeldDown;

        // Body claculations
        private bool spaceHeldDown = false;

        public Player()
        {
            color = Color.White;
            speed = 500f;
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
            //Apply gravity

            velocity += new Vector2(0f, 0.05f);


            //Apply velocity
            //position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
                //Try to disable jumping in the air. Not perfect, would be better to check if player is on ground.
                if (!wHeldDown)
                    velocity = new Vector2(velocity.X, -1);
                wHeldDown = true;
            }
            else
                wHeldDown = false;

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

            //if we press S
            if (keyState.IsKeyDown(Keys.S))
            {
                //move down
                velocity += new Vector2(0, 1);
            }

            if (keyState.IsKeyDown(Keys.Space))
            {
                //ADD attack
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

        public override void OnCollision(GameObject gameObject)
        {
            this.offset = new Vector2(sprite.Width / -2, sprite.Height * -1); //Centers the Collison box
        }
    }
}

