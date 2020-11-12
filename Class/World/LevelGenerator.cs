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

                levelList.Add(new SmallPlatform(new Vector2(400, 800)));
                levelList.Add(new SmallPlatform(new Vector2(800, 500)));

                levelList.Add(new SmallPlatform(new Vector2(1200, 700)));

                levelList.Add(new Platform(new Vector2(100, 600)));

                levelList.Add(new LargePlatform(new Vector2(800, 200)));
                levelList.Add(new LargePlatform(new Vector2(1300, 550)));

                //-127 er fjendes højde (pånær 1px. der gør at den konstant collidere for at tjekke om den skal vende)
                //hvor mange fjnder er der i dette level.
                GameManager.monstersLeft = 3;
                levelList.Add(new Enemy(new Vector2(1450, 550-127), 0, 5));
                levelList.Add(new Enemy(new Vector2(800, 200-127), 1, 5));
                levelList.Add(new Enemy(new Vector2(170, 600-127), 1, 5));

                levelList.Add(new Portal(new Vector2(-1400, 722)));

            }

            if (levelProgression == 2) 
            {
                levelList.Add(new Floor(new Vector2(0, 992)));


                levelList.Add(new SmallPlatform(new Vector2(1327, 782)));
                levelList.Add(new SmallPlatform(new Vector2(1093, 700)));
                levelList.Add(new SmallPlatform(new Vector2(666, 610)));
                levelList.Add(new SmallPlatform(new Vector2(276, 420)));


                levelList.Add(new LargePlatform(new Vector2(81, 780)));
                levelList.Add(new Platform(new Vector2(598, 131)));
                levelList.Add(new LargePlatform(new Vector2(1216, 269)));

                GameManager.monstersLeft = 4;
                levelList.Add(new Enemy(new Vector2(90, 780 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(600, 131 - 127), 0, 5));
                levelList.Add(new Enemy(new Vector2(1220, 269 - 127), 0, 5));
                levelList.Add(new Enemy(new Vector2(1000, 992 - 127), 1, 5));

                levelList.Add(new Portal(new Vector2(-1400, 722)));
            }

            if (levelProgression == 3)
            {
                levelList.Add(new Floor(new Vector2(0, 992)));


                levelList.Add(new SmallPlatform(new Vector2(188, 441)));
                levelList.Add(new SmallPlatform(new Vector2(1092, 250)));
                levelList.Add(new SmallPlatform(new Vector2(1330, 250)));
                levelList.Add(new SmallPlatform(new Vector2(1572, 250)));
                levelList.Add(new SmallPlatform(new Vector2(1300, 770)));

                levelList.Add(new LargePlatform(new Vector2(408, 441)));
                levelList.Add(new LargePlatform(new Vector2(650, 690)));
                levelList.Add(new Platform(new Vector2(1360, 460)));


                GameManager.monstersLeft = 7;
                levelList.Add(new Enemy(new Vector2(540, 441 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(1100, 250 - 127), 0, 5));
                levelList.Add(new Enemy(new Vector2(1666, 250 - 127), 1, 5));

                levelList.Add(new Enemy(new Vector2(700, 690 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(1370, 460 - 127), 0, 5));

                levelList.Add(new Enemy(new Vector2(140, 992 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(980, 992 - 127), 0, 5));

                levelList.Add(new Portal(new Vector2(-1400, 722)));

            }

            if (levelProgression == 4)
            {
                levelList.Add(new Floor(new Vector2(0, 992)));

                GameManager.monstersLeft = 8;
                levelList.Add(new Enemy(new Vector2(540, 992 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(1100, 992 - 127), 0, 5));
                levelList.Add(new Enemy(new Vector2(1666, 992 - 127), 1, 5));

                levelList.Add(new Enemy(new Vector2(700, 992 - 127), 1, 5));
                levelList.Add(new Enemy(new Vector2(1370, 992 - 127), 0, 5));

                levelList.Add(new Enemy(new Vector2(640, 992 - 127), 0, 5));
                levelList.Add(new Enemy(new Vector2(880, 992 - 127), 1, 5));
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
