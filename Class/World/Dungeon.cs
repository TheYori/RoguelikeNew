using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World
{
    class Dungeon : GameObject
    {

        protected Theme dungeonTheme;
        protected Level level; 

        public Dungeon(Theme theme, Level level)
        {
            this.level = level;
            this.dungeonTheme = theme;
            color = Color.White;
            origin = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
            if(dungeonTheme == Theme.science)
            {
                sprite = content.Load<Texture2D>("ScienceLabBackDrop");
            }

        }

        public override void Update(GameTime gameTime)
        {
   
        }

        public void InitiateLevel(int levelProgression)
        {

        }

        public override void onCollision(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
