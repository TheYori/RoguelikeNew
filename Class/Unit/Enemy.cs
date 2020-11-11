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


namespace Roguelike.Class
{
    class Enemy : Unit
    {

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
        private float alpha = 1f;
        public Color myColor = Color.White;
        private float layerDepth;
        public Rectangle EnemyRectangle
        {
            get
            {
                return new Rectangle(
                       (int)(_position.X + offset.X),
                       (int)(_position.Y + offset.Y),
                       enemyTexture.Width,
                       enemyTexture.Height
                   );
            }
            set
            {
                enemyRectangle = value;
            }
        }

        public float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                if (value > 0)
                {
                    alpha = value;
                }
                else
                {
                    alpha = 0;
                }
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


        public Enemy(Vector2 position, int direction, int health)
        {

            color = Color.White * Alpha;

            _position = position;
            Type = UnitType.AnEnemy;
            
            if (direction == 0)
            {
                isMovingLeft = true;
            }
            else
            {
                isMovingRight = true;
            }

            this.health = health;

        }

        public override void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            deltaTime = delta;

  

            if (gameStart == false)
            {
                effects = SpriteEffects.FlipHorizontally;
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


            if (moveTime > 0 && isMoving == true)
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
            else if (moveTime < 0 && isMoving == true)
            {
                if (isMovingRight == true)
                {
                    isMovingRight = false;
                    isMovingLeft = true;
                }
                else if (isMovingLeft == true)
                {
                    isMovingLeft = false;
                    isMovingRight = true;
                }
                moveTime = maxMoveTime;
            }

            if (health <= 0)
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
                myColor = Color.Red;
                colorDuration -= deltaTime;

            }
            if (colorDuration < 0 && isHit == true)
            {
                isHit = false;
                myColor = Color.White;
                colorDuration = 0.5f;
            }

            #region Debug

            //-- Debug Movement --//
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    isMoving = true;
            //    _position.X += speed * delta;
            //    effects = SpriteEffects.FlipHorizontally;

            //}

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
            _position.X += speed * deltaTime;
            effects = SpriteEffects.FlipHorizontally;
        }

        /// <summary>
        /// Move enemy left
        /// </summary>
        public void MoveLeft()
        {
            isMoving = true;
            _position.X -= speed * deltaTime;
            effects = SpriteEffects.None;
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
            isMoving = false;
            myColor = Color.Red;
            Alpha -= 0.02f;

        }

        /// <summary>
        /// Reveals sprites. ONLY FOR DEBUGGING
        /// </summary>
        public void Reveal()
        {
            isEnemyDead = false;
            Alpha += 0.02f;
            myColor = Color.White;
        }



    }
}
