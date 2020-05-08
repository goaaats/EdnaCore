using System;
using System.Collections.Generic;
using System.Text;
using EdnaCore.Scenes;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EdnaCore
{
    class CursorManager
    {
        private Texture2D _crossHairCursor;
        private Texture2D _crossHairCursorActivated;

        private CursorKind _currentCursor = CursorKind.Crosshair;

        public CursorManager(ContentManager content)
        {
            _crossHairCursor = content.Load<Texture2D>("visual/gui/edna/cursor");
            _crossHairCursorActivated = content.Load<Texture2D>("visual/gui/edna/cursor_a");

            Mouse.SetCursor(MouseCursor.FromTexture2D(_crossHairCursor, 20, 20));
        }
    }
}
