using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EdnaCore.WAM
{
    class WalkableAreaMap
    {
        private readonly bool[][] _wamData;

        private const int WAM_WIDTH = 800;
        private const int WAM_HEIGHT = 600;

        public WalkableAreaMap(byte[] data)
        {
            _wamData = new bool[WAM_WIDTH][];
            var wamAt = 0;

            for (var x = 0; x < WAM_WIDTH; ++x)
            {
                _wamData[x] = new bool[WAM_HEIGHT];
                for (var y = 0; y < WAM_HEIGHT; ++y)
                {
                    _wamData[x][y] = data[wamAt] == 0x01;
                    wamAt++;
                }
            }
        }

        private Texture2D _wamDebugTexture2D;

        public void DrawDebug()
        {
            if (_wamDebugTexture2D == null)
            {
                _wamDebugTexture2D = new Texture2D(Debug.Graphics.GraphicsDevice, WAM_WIDTH, WAM_HEIGHT);

                var data = new Color[WAM_WIDTH * WAM_HEIGHT];
                var wamAt = 0;
                for (var x = 0; x < WAM_WIDTH; ++x)
                {
                    for (var y = 0; y < WAM_HEIGHT; ++y)
                    {
                        data[x + (WAM_WIDTH * y)] = _wamData[x][y] ? Color.White : Color.Black;
                        wamAt++;
                    }
                }

                _wamDebugTexture2D.SetData(data);
            }

            Debug.SpriteBatch.Draw(_wamDebugTexture2D, Vector2.Zero, Color.White);
        }

        public (bool notFound, Queue<Point> pathPoints) FindPath(Point from, Point to)
        {
            var pathQueue = new Queue<Point>();
            var notFound = false;

            return (notFound, pathQueue);
        }
    }
}
