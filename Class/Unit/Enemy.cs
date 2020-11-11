using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct3D9;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework.Audio;

namespace Roguelike.Class
{
    class Enemy : Unit
    {
        // Sound
        private SoundEffectInstance deathSound;
        // - Draw parameters -//
        private Texture2D enemyTexture;
        private Texture2D[] myfishy = new Texture2D[6];
        private Rectangle enemyRectangle;
        private Vector2 _position;
        private float scale = 0.5f;
        private Vector2 origin = Vector2.Zero;
        private float rotation;
        private SpriteEffects effects = new SpriteEffects();
        private SpriteEffects s = SpriteEffects.FlipHorizontally;
        
        public Color myColor = Color.White;
        private float layerDepth;
        public Rectangle EnemyRectangle
        {
            get
            {
                return new Rectangle(
                       (int)(base.position.X + offset.X),
                       (int)(base.position.Y + offset.Y),
                       enemyTexture.Width,
                       enemyTexture.Height
                   );
            }
            set
            {
                enemyRectangle = value;
            }
        }

  
        // - Misc bools -//
        public bool gameStart;
        public bool stateOne = true;
        public bool stateTwo;
        public bool isMoving = true;
        public bool isMovingRight;
        public bool isMovingLeft;
        public bool isTestKeyDown = false;


        //GetHit

        public int blinks = 1;
        public bool isHit;
        public float colorDuration = 0.5f;


        // - Delta time, timers and max values -//

        public float deltaTime;

        public float behaviorTime = 4;
        public float deathTime = 4;
        private float moveTime = 3;
        private float maxMoveTime = 3;

        public int fishProgress = 0;
        public float fps = 15;
        public float timeElapsed;
        public bool isEnemyDead;
        public Vector2 testPosition = new Vector2(500f, 0f);
        public Vector2 offset;

        // - 

        private float speed = 150;


        private int ID;

        Random rnd = new Random();
        private int enemyDirection;


        //  public Enemy(Vector2 position, int direction, int health)
        public Enemy(Vector2 position, int direction, int health)
        {
            base.alpha = 1f;
            base.color = Color.White * base.Alpha;
            //color = Color.White * Alpha;

            base.position = position;
            
            Type = UnitType.AnEnemy;
//            enemyDirection = direction;


            if (direction == 0)
            {
                isMovingLeft = true;
            }
            else
            {
                isMovingRight = true;
            }

            base.health = health;

        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            deltaTime = delta;



            if (gameStart == false)
            {
                effects = SpriteEffects.FlipHorizontally;
                base.effects = base.s;
                //int enemyDirection = rnd.Next(1, 2);
                gameStart = true;

                if (enemyDirection == 0)
                {
                    isMovingLeft = true;
                }
                else if (enemyDirection == 1)
                {
                    isMovingRight = true;
                }

            }


            if (isMoving == true)
            {
                moveTime -= delta;
                if (isMovingRight == true)
                {
                    MoveRight();
                }
                else if (isMovingLeft == true)
                {
                    MoveLeft();
                }
            }
           

            if (base.health <= 0)
            {
                isEnemyDead = true;
            }


            if (isMoving == true)
            {
                AnimateE(gameTime);
            }

            if (isEnemyDead == true)
            {
                EnemyDeath();

            }

            if (isHit == true)
            {
                base.color = Color.Red;
                colorDuration -= deltaTime;

            }
            if (colorDuration < 0 && isHit == true)
            {
                isHit = false;
                base.color = Color.White;
                colorDuration = 0.5f;
            }

            if (isEnemyDead == true && base.Alpha < 0)
            {
                GameManager.RemoveObject(this);
            }


            #region Debug

            //-- Debug Movement --//
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    isMoving = true;
            //    _position.X += speed * delta;
            //    effects = SpriteEffects.FlipHorizontally;

            //}


            /*
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                deathSound.Play();

            }
            */


            //else if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{
            //    isMoving = true;
            //    _position.X -= speed * delta;
            //    effects = SpriteEffects.None;
            //}

            //else if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    isMoving = true;
            //    _position.Y -= speed * delta;
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    isMoving = true;
            //    _position.Y += speed * delta;

            //}
            //else
            //{
            //    isMoving = false;
            //}


            //Debug - death
            /*
            if (Keyboard.GetState().IsKeyDown(Keys.N))
            {


                isEnemyDead = true;


            }

            */

            //Debug - reveal

            //if (Keyboard.GetState().IsKeyDown(Keys.M))
            //{
            //    Reveal();
            //}




            //--Debug DealDamage() -- //

            //if(Keyboard.GetState().IsKeyDown(Keys.L))
            //{
            //    if (isTestKeyDown == false)
            //    {

            //        DealDamage(5);
            //        isTestKeyDown = true;
            //    }

            //}
            //else if(Keyboard.GetState().IsKeyUp(Keys.L))
            //{
            //        isTestKeyDown = false;

            //}


            //if (Keyboard.GetState().IsKeyDown(Keys.L))
            //{
            //    if (isTestKeyDown == false)
            //    {

            //        base.DealDamage(5);
            //        isTestKeyDown = true;
            //    }



            //}
            #endregion
        }

        public override void Initialize()
        {

        }

       
        public override void LoadContent(ContentManager Content)
        {


            enemyTexture = Content.Load<Texture2D>("EnemyF1");

            myfishy[0] = Content.Load<Texture2D>("EnemyF1");
            myfishy[1] = Content.Load<Texture2D>("EnemyF2");
            myfishy[2] = Content.Load<Texture2D>("EnemyF3");
            myfishy[3] = Content.Load<Texture2D>("EnemyF4");
            myfishy[4] = Content.Load<Texture2D>("EnemyF5");
            myfishy[5] = Content.Load<Texture2D>("EnemyF6");


            enemyRectangle = new Rectangle(0, 0, enemyTexture.Width, enemyTexture.Height);
            sprite = enemyTexture;

            deathSound = Content.Load<SoundEffect>("DeathSound").CreateInstance();


        }




        public void Hit()
        {
            DealDamage(5);
            isHit = true;
        }


        /// <summary>
        /// Move enemy right;
        /// </summary>
        public void MoveRight()
        {
            isMoving = true;
            base.position.X += speed * deltaTime;
            base.effects = base.s;
        }

        /// <summary>
        /// Move enemy left
        /// </summary>
        public void MoveLeft()
        {
            isMoving = true;
            base.position.X -= speed * deltaTime;
            base.effects = SpriteEffects.None;
        }


        /// <summary>
        /// Animate enemy Sprite
        /// </summary>
        protected void AnimateE(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            fishProgress = (int)(timeElapsed * fps);
            if (fishProgress > myfishy.Length - 1)
            {
                timeElapsed = 0;
                fishProgress = 0;
            }
            sprite = myfishy[fishProgress];

        }

        /// <summary>
        /// Stops Enemy movement and makes it fade away;
        /// </summary>
        public void EnemyDeath()
        {
            deathSound.Play();
            isMoving = false;
           base.color = Color.Red;
            base.Alpha -= 0.02f;

        }

        /// <summary>
        /// Reveals sprites. ONLY FOR DEBUGGING
        /// </summary>
        public void Reveal()
        {
            isEnemyDead = false;
            base.Alpha += 0.02f;
            base.color = Color.White;
        }

        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Player)
            {
                gameObject.health--;
                

            }

                if (gameObject is Environment)
            {


               if(position.X + sprite.Width > gameObject.position.X + gameObject.sprite.Width)
                {
                    isMovingLeft = true;
                    isMovingRight = false;

                }

                if (position.X < gameObject.position.X )
                {
                    isMovingLeft = false;
                    isMovingRight = true;

                }



            }
        }


    }
}
