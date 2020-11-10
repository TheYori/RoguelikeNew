using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World
{

    class Level : GameObject
    {

        private Rectangle borderSize;
        private List<GameObject> enviromentList; //have a spelling error - if corrected it WILL create issues

        public override void Initialize()
        {

        }

        public List<GameObject>  EnviromentList
        {
            get
            {
                return enviromentList;
            }
            }

        public Level(int mapSizeWidth, int mapSizeHeight, List<GameObject> enviromentList)
        {
            borderSize = new Rectangle(0, 0, mapSizeWidth, mapSizeHeight);
            this.enviromentList = enviromentList;
        }

        public override void LoadContent(ContentManager content)
        {


        }

        public override void OnCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {

        }

    }
}
