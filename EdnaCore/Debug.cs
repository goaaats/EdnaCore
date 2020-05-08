using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EdnaCore
{
    class Debug
    {
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;

        public static bool DrawButtonRects = false;
        public static bool DrawWalkableAreaMap = false;
        public static bool DrawRaumObjektRects = false;

        public static void DrawRect(Rectangle rectangle)
        {
            var rect = new Texture2D(Graphics.GraphicsDevice, rectangle.Width, rectangle.Height);

            var data = new Color[rectangle.Width * rectangle.Height];
            for (var i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rect.SetData(data);

            var coor = new Vector2(rectangle.X, rectangle.Y);
            SpriteBatch.Draw(rect, coor, Color.White);
        }
    }
}
