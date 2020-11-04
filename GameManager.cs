using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Class;
using Roguelike.Class.World;
using Roguelike.Class.World.tempClass;
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

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 2080;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            environmentList = new List<Environment>();
            // TODO: Add your initialization logic here
            DummyPlayer player = new DummyPlayer();
            Environment testEnviroment = new Environment(new Vector2(500,300));

            environmentList.Add(testEnviroment);


            Dungeon scienceDungeon = new Dungeon(Theme.science, new Level(2080, 1080, player, environmentList));



            gameObjects = new List<Class.GameObject>();
            gameObjects.Add(scienceDungeon);
            gameObjects.Add(player);
            gameObjects.Add(testEnviroment);

    
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach(GameObject obj in gameObjects)
            {
                obj.LoadContent(this.Content);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime);
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
            }

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
