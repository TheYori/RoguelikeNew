using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike.Class.UI
{
    class UIManager : GameObject
    {
        protected Vector2 _position;
        protected float layerDepth;
        protected Vector2 _origin = Vector2.Zero;
        protected SpriteEffects effect = new SpriteEffects();


        public UIManager(Vector2 Position)
        {
            position = Position; 
        }
        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void OnCollision(GameObject gameObject)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
