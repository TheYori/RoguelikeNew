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
        
        public Dungeon(Theme theme)
        {
            this.dungeonTheme = theme;
        }

        public override void LoadContent(ContentManager content)
        {
            if(dungeonTheme == Theme.science)
            {
                sprite = content.Load<Texture2D>("ScienceLabBackDrop");
            }

        }


    }
}
