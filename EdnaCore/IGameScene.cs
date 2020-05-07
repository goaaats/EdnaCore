using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EdnaCore
{
    internal interface IGameScene
    {
        public IGameScene ParentScene { get; set; }
        public void Draw(GameTime time, SpriteBatch spriteBatch);
        public void LoadContent(ContentManager content);
    }
}
