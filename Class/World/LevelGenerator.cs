using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
 
                levelList.Add(new Platform(new Vector2(400, 450)));
                levelList.Add(new Platform(new Vector2(800, 450)));
                levelList.Add(new Portal(new Vector2(1400, 500)));

            }

            if (levelProgression == 2) 
            {

                levelList.Add(new Platform(new Vector2(400, 250)));
                levelList.Add(new Platform(new Vector2(800, 300)));
                levelList.Add(new Platform(new Vector2(800, 500)));
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
