using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Roguelike.Class;
using Roguelike.Class.UI;
using Roguelike.Class.World;
using Roguelike.Class.World.DungeonContent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Roguelike
{
    public enum Theme { tempel, science }

    public class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        

        protected Vector2 position;
        protected Rectangle collisionBox;

        private static List<GameObject> gameObjects;
        public static List<GameObject> environmentList;
        static List<GameObject> removeList;
        private static List<GameObject> addObject;
        private static List<Heart> hearts;
        public static Counter monsterUI;

        

        public static int monstersLeft;

      

        public static LevelGenerator lg;

        //player
        public static Player player;
        protected static Vector2 screenSize;
        private Texture2D collisionTexture;
        public static Vector2 GetScreenSize { get => screenSize; }
        public static ContentManager content;
        public MeleeWeapon weapon;
        Dungeon currentDungeon;

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
            screenSize = new Vector2(1920, 1080);
            _graphics.PreferredBackBufferWidth = (int)screenSize.X;
            _graphics.PreferredBackBufferHeight = (int)screenSize.Y;
            _graphics.ApplyChanges();

            lg = new LevelGenerator();

            addObject = new List<GameObject>();
            removeList = new List<GameObject>();
            gameObjects = new List<GameObject>();
            environmentList = new List<GameObject>();
            weapon = new MeleeWeapon(new Vector2(0, 0));
            // TODO: Add your initialization logic here
            player = new Player(weapon);
            hearts = new List<Heart>(3) {
                new Heart(new Vector2(150, 150), 0.05f),
                new Heart(new Vector2(250, 150),0.05f),
                new Heart(new Vector2(350, 150), 0.05f)
              };
            monsterUI = new Counter(new Vector2(150, 250), 0.2f, 0);
            currentDungeon = new Dungeon(Theme.science, new Level((int)screenSize.X, (int)screenSize.Y, environmentList));

            //gameObjects.Add(currentDungeon);
            gameObjects.Add(weapon);
            gameObjects.Add(currentDungeon);
            gameObjects.Add(player);



            foreach (GameObject obj in hearts)
            {
                gameObjects.Add(obj);
            }
            gameObjects.Add(monsterUI);

    
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            content = this.Content;

            ChangeLevel(levelProgression);

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            foreach (GameObject obj in gameObjects)
            {
                obj.LoadContent(content);
            }



            // TODO: use this.Content to load your game content here



            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach(GameObject obj in removeList)
            {
                gameObjects.Remove(obj);
            }
            removeList.Clear();

            foreach (GameObject obj in addObject)
            {
                gameObjects.Add(obj);
            }

            addObject.Clear();


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
               // DrawCollisionBox(obj);
                #endif
            }

            monsterUI.Draw( _spriteBatch);
                

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static void ChangeLevel(int levelProgress)
        {

            foreach (GameObject obj in environmentList)
            {
                RemoveObject(obj);
            }
             
            environmentList = lg.CreateLevel(levelProgress, content);

            foreach (GameObject obj in environmentList)
            {
                AddObject(obj);
            }

     

        }

        public static void UpdateHealthUi(int health) {

            if(health >= 0)
            {
                RemoveObject(hearts[health]);

            }


            if (health == 0)
            {
                RemoveObject(player);
            }

        }

        public static void SpawnPortal() { 
        
        foreach(GameObject obj in gameObjects)
            {
                if(obj is Portal)
                {
                    obj.position.X = 800;
                }
            }
                
                    }



        public static void AddObject(GameObject obj)
        {
            addObject.Add(obj);
        }

        public static void RemoveObject(GameObject obj)
        {
            removeList.Add(obj);
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
