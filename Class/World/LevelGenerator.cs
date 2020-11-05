using Microsoft.Xna.Framework;
using Roguelike.Class.World.DungeonContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
{
      public static class LevelGenerator
    {


        public static List<Environment> CreateEnviromentList(int levelProgression)
        {
            List<Environment> levelList = new List<Environment>();

            levelList.Clear();


            if (levelProgression == 1)
            {

                levelList.Add(new Platform(new Vector2(400, 100)));
                levelList.Add(new Platform(new Vector2(800, 100)));
                levelList.Add(new Portal(new Vector2(800, 500)));
            }

            if (levelProgression == 2)
            {

                levelList.Add(new Platform(new Vector2(400, 250)));
                levelList.Add(new Platform(new Vector2(800, 300)));
                levelList.Add(new Platform(new Vector2(800, 500)));
            }



            return levelList;
        }
    }
}
