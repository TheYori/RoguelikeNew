﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.World.DungeonContent
{
   public class NPC : Environment
    {

        public NPC(Vector2 Position) : base(Position)
        {
            color = Color.White;
            origin = Vector2.Zero;


        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("charecterDesign2");


        }

        public override void OnCollision(GameObject gameObject)
        {


            base.OnCollision(gameObject);
        }
    }
}
