using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Class.World;
using Roguelike.Class.World.DungeonContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class
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

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
   
        }

        public void InitiateLevel(int levelProgression)
        {
           
        }

        public override void OnCollision(GameObject gameObject)
        {
        
        }
    }
}
