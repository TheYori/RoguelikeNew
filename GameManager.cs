using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Class;
using Roguelike.Class.World;
using Roguelike.Class.World.DungeonContent;
using System.Collections.Generic;

namespace Roguelike
{
    public enum Theme { tempel, science }

    public class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        protected Vector2 position;
        protected Rectangle collisionBox;

        private List<GameObject> gameObjects;
        private List<Environment> environmentList;

        //player
        protected static Vector2 screenSize;
        private Texture2D collisionTexture;


        Dungeon scienceDungeon;

       public static int levelProgression;

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            levelProgression = 1;
            screenSize = new Vector2(2080, 1080);
            _graphics.PreferredBackBufferWidth = (int)screenSize.X;
            _graphics.PreferredBackBufferHeight = (int)screenSize.Y;
            _graphics.ApplyChanges();



            environmentList = LevelGenerator.CreateEnviromentList(levelProgression);

            // TODO: Add your initialization logic here
            Player player = new Player();
            

            scienceDungeon = new Dungeon(Theme.science, new Level((int)screenSize.X, (int)screenSize.Y, environmentList));

            gameObjects = new List<GameObject>();
            gameObjects.Add(scienceDungeon);

            foreach (GameObject obj in environmentList)
            {
                gameObjects.Add(obj);
            }



            gameObjects.Add(player);


    
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach(GameObject obj in gameObjects)
            {
                obj.LoadContent(this.Content);
            }

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (GameObject obj in environmentList)
            {
                gameObjects.Add(obj);
            }

            environmentList.Clear();

            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime);
           

                foreach (GameObject other in gameObjects)
                {
                    obj.CheckCollision(other);
                }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(_spriteBatch);

                #if DEBUG
                DrawCollisionBox(obj);
                #endif
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ChangeLevel(int levelProgress)
        {
                environmentList = LevelGenerator.CreateEnviromentList(2);
               
        }

        private void DrawCollisionBox(GameObject go)
        {
            Rectangle topLine = new Rectangle(go.CollisionBox.X, go.CollisionBox.Y, go.CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(go.CollisionBox.X, go.CollisionBox.Y + go.CollisionBox.Height, go.CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(go.CollisionBox.X + go.CollisionBox.Width, go.CollisionBox.Y, 1, go.CollisionBox.Height);
            Rectangle leftLine = new Rectangle(go.CollisionBox.X, go.CollisionBox.Y, 1, go.CollisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, Color.Red);
            _spriteBatch.Draw(collisionTexture, bottomLine, Color.Red);
            _spriteBatch.Draw(collisionTexture, rightLine, Color.Red);
            _spriteBatch.Draw(collisionTexture, leftLine, Color.Red);
        }
    }
}
