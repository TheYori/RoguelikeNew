using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Roguelike.Class.UI;
using Roguelike.Class.World.DungeonContent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Roguelike.Class
{
      public  class LevelGenerator : GameObject
    {


        public List<GameObject> CreateLevel(int levelProgression, ContentManager content)
        {
            List<GameObject> levelList = new List<GameObject>();

            levelList.Clear();

            if (levelProgression == 1)
            {
                levelList.Add(new Floor(new Vector2(0, 992)));
                levelList.Add(new Heart(new Vector2(100, 100), 0.05f));
                levelList.Add(new Heart(new Vector2(200, 100), 0.05f));
                levelList.Add(new Heart(new Vector2(300, 100), 0.05f));

                levelList.Add(new Enemy(new Vector2(800,80),1,5));
                levelList.Add(new SmallPlatform(new Vector2(400, 800)));
                levelList.Add(new SmallPlatform(new Vector2(800, 500)));
                levelList.Add(new LargePlatform(new Vector2(800, 200)));

                levelList.Add(new Enemy(new Vector2(120, 480), 1, 5));
                levelList.Add(new Platform(new Vector2(100, 600)));
              

                levelList.Add(new Portal(new Vector2(1400, 500)));

            }

            if (levelProgression == 2) 
            {
                levelList.Add(new Floor(new Vector2(0, 992)));
                levelList.Add(new Platform(new Vector2(400, 250)));
                levelList.Add(new Platform(new Vector2(800, 300)));
                levelList.Add(new Platform(new Vector2(800, 500)));
                levelList.Add(new Portal(new Vector2(100, 500)));
            }

            if (levelProgression == 3)
            {
                levelList.Add(new Floor(new Vector2(0, 992)));
                levelList.Add(new Platform(new Vector2(400, 200)));
                levelList.Add(new Platform(new Vector2(800, 100)));
                levelList.Add(new Platform(new Vector2(200, 500)));

            }


            foreach (GameObject obj in levelList) {
                obj.Initialize();
                obj.LoadContent(content);
            }

            return levelList;
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
