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
using Environment = Roguelike.Class.Environment;

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

        //Fields for melee attack
        private Vector2 spawnOffset;
        private bool spaceHeldDown;
        private GameObject weapon;

        private BoostItem[] boostList;

        // Fields for movements
        private bool jumpHeldDown;
        private bool jumpAllowed;

        //bool dashHeldDown;

        public Player(MeleeWeapon myweapon)
        {
            color = Color.White; 
            fps = 6;
            speed = 500f;
            Type = UnitType.APlayer;
            weapon = myweapon;
        }

        public override void Update(GameTime gameTime)
        {
            //Visuals
            Animate(gameTime);

            //Movement
            HandleInput();
            ApplyPhysics(gameTime);
            Move(gameTime);
            Dash(gameTime);
            Attack();

            //Other
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
            if (keyState.IsKeyDown(Keys.W) && jumpAllowed == true)
            {
                // Allows the player to go up, but 
                //stops the player to continue to do so, bu holding the key.
                if (!jumpHeldDown)
                    velocity = new Vector2(velocity.X, -2f);
                    jumpHeldDown = true;
                    jumpAllowed = false;
            }
            else
                jumpHeldDown = false;

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
        }  //Left, Right, Jump

        private void Dash(GameTime gameTime)
        {

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.D) && keyState.IsKeyDown(Keys.LeftShift))
            {
                {
                    position += new Vector2(50, 0);
                }
            }

            if (keyState.IsKeyDown(Keys.A) && keyState.IsKeyDown(Keys.LeftShift))
            {
                    position += new Vector2(-50, 0);
            }
        }  //"Dash" is technically a movement, but since we need to [manipulate] it, "Dash" have its own method

        private void Attack()
        {
            

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Space) && spaceHeldDown == true)
            {
                GameManager.AddObject(weapon);
                spaceHeldDown = false;
            }
            if (!keyState.IsKeyDown(Keys.Space) && spaceHeldDown == false)
            {
                GameManager.RemoveObject(weapon);
                spaceHeldDown = true;
            }
        }

        public override void Initialize()
        {
 
        }

        private void Collect()
        {
            // Player colli
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
            // Spawns weapon away from player
            spawnOffset = new Vector2(50, -105);
            sprite = content.Load<Texture2D>("weaponRight");

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
            if (gameObject is Environment)
            {
                // Get the current keyboard state
                KeyboardState keyState = Keyboard.GetState();

                if (gameObject.position.Y - gameObject.sprite.Height > position.Y - sprite.Height && !keyState.IsKeyDown(Keys.W))
                {
                    jumpAllowed = true;
                }
               
            }
        }
    }
}

