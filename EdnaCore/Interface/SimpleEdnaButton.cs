using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EdnaCore.Interface
{ class SimpleEdnaButton
    {
        private Point _position;
        private Texture2D _graphicDefault;
        private Texture2D _graphicHovered;

        public SimpleEdnaButton(ContentManager content, string path, Point position)
        {
            _position = position;
            _graphicDefault = content.Load<Texture2D>(path);
            _graphicHovered = content.Load<Texture2D>(path + "_a");
        }

        public bool Draw(SpriteBatch spriteBatch)
        {
            var clickRect = new Rectangle(_position, new Point(_graphicDefault.Width, _graphicDefault.Height));

            var isHover = clickRect.Contains(Mouse.GetState().Position);

            spriteBatch.Draw(isHover ? _graphicHovered : _graphicDefault, _position.ToVector2(), Color.White);

            if (Debug.DrawButtonRects)
                Debug.DrawRect(clickRect);

            return isHover && Mouse.GetState().LeftButton == ButtonState.Pressed;
        }
    }
}
