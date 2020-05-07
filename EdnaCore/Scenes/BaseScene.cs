using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EdnaCore.Scenes
{
    class BaseScene : IGameScene
    {
        public IGameScene ParentScene { get; set; }

        #region CursorTextures

        private Texture2D _crossHairCursor;
        private Texture2D _crossHairCursorActivated;

        private CursorKind _currentCursor = CursorKind.Crosshair;

        #endregion

        private IGameScene _subScene;

        public void LoadContent(ContentManager content)
        {
            _crossHairCursor = content.Load<Texture2D>("visual/gui/edna/cursor");
            _crossHairCursorActivated = content.Load<Texture2D>("visual/gui/edna/cursor_a");

            Mouse.SetCursor(MouseCursor.FromTexture2D(_crossHairCursor, 20, 20));

            _subScene = new MainMenuScene()
            {
                ParentScene = this
            };
            _subScene.LoadContent(content);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            _subScene.Draw(time, spriteBatch);
        }
    }
}
