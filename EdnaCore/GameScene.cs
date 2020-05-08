using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EdnaCore
{
    internal abstract class GameScene
    {
        public GameScene(EdnaGame game, GameScene parentScene = null)
        {
            Game = game;
            ParentScene = parentScene;
        }

        public EdnaGame Game { get; private set; }
        public GameScene ParentScene { get; private set; }
        public abstract void Draw(GameTime time, SpriteBatch spriteBatch);
        public abstract void LoadContent();
    }
}
