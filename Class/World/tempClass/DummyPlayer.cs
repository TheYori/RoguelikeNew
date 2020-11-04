using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World.tempClass
{
    class DummyPlayer : GameObject
    {

        private Vector2 velocity;
        private float speed;

        public DummyPlayer()
        {
            base.position = new Vector2(10,10);
            color = Color.White;
            origin = Vector2.Zero;

            speed = 50;


        }

        public override void LoadContent(ContentManager content)
        {
     
                    sprite = content.Load<Texture2D>("dummyPlayer");
                    collisionBox = new Rectangle((int)position.X,(int)position.Y, sprite.Width, sprite.Height);

        }



        public void Move(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;



            if (velocity.Length() != 0)
            {


                position += ((velocity * speed) * deltaTime);


            }


            //du gange med deltaTime, så der ikke er forskel på hvor hurtigt du bevæger dig, uanset Frams per seconds (FPS)

        }
        public void HandelInput()
        {

            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }

            if (input.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }

            if (input.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }

            if (input.IsKeyDown(Keys.W))
            {

                velocity += new Vector2(0, -1);
            }

            if(input.IsKeyUp(Keys.D) && input.IsKeyUp(Keys.A) && input.IsKeyUp(Keys.W) && input.IsKeyUp(Keys.S))
            {
                velocity = Vector2.Zero;
            }
        }

        public override void Update(GameTime gameTime)
        {
            HandelInput();
            Move(gameTime);
        }

        public override void onCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
