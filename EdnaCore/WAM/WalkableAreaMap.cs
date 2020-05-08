using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using MathNet.Spatial.Euclidean;
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
                        data[x + (WAM_WIDTH * y)] = _wamData[x][y] ? new Color(245, 66, 245, 180) : new Color();
                        wamAt++;
                    }
                }

                _wamDebugTexture2D.SetData(data);
            }

            Debug.SpriteBatch.Draw(_wamDebugTexture2D, Vector2.Zero, Color.White);
        }

        public Stack<Point> FindPath(Point from, Point to)
        {
            var pfGrid = new int[WAM_WIDTH][];
            for (var i = 0; i < WAM_WIDTH; i++)
            {
                pfGrid[i] = new int[WAM_HEIGHT];
                Array.Fill(pfGrid[i], -1);
            }

            // Correct start & end position
            from = GetNearestWamPoint(from);
            to = GetNearestWamPoint(to);

            var workQueue = new Queue<Point>();
            var notFound = true;

            pfGrid[from.X][from.Y] = 0;

            var curPoint = from;

            while (notFound)
            {
                if (curPoint == to)
                {
                    notFound = false;
                }
                else
                {
                    var n = pfGrid[curPoint.X][curPoint.Y] + 2;
                    --curPoint.Y;

                    if (curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    ++curPoint.X;
                    ++curPoint.Y;

                    if (curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    ++curPoint.Y;

                    if (--curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    --curPoint.Y;

                    if (--curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    ++n;
                    --curPoint.Y;

                    if (curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    ++curPoint.X;

                    if (++curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    ++curPoint.Y;
                    ++curPoint.Y;

                    if (curPoint.X >= 0 && curPoint.X < WAM_WIDTH && curPoint.Y >= 0 && curPoint.Y < WAM_HEIGHT && pfGrid[curPoint.X][curPoint.Y] == -1 && _wamData[curPoint.X][curPoint.Y])
                    {
                        pfGrid[curPoint.X][curPoint.Y] = n;
                        workQueue.Enqueue(curPoint);
                    }

                    --curPoint.X;

                    if (--curPoint.X < 0 || curPoint.X >= WAM_WIDTH || curPoint.Y < 0 || curPoint.Y >= WAM_HEIGHT || pfGrid[curPoint.X][curPoint.Y] != -1 || !_wamData[curPoint.X][curPoint.Y])
                    {
                        continue;
                    }

                    pfGrid[curPoint.X][curPoint.Y] = n;
                    workQueue.Enqueue(curPoint);
                }
            }

            var deltaX = 0;
            var deltaY = 0;
            var resultPoints = new Stack<Point>();

            while (from.X != to.X || from.Y != to.Y)
            {
                curPoint = to;

                var n = pfGrid[curPoint.X][curPoint.Y];
                var dX = 0;
                var dY = 0;
                --curPoint.Y;
                if (curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = 0;
                    dY = -1;
                }
                ++curPoint.X;
                ++curPoint.Y;
                if (curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = 1;
                    dY = 0;
                }
                ++curPoint.Y;
                if (--curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = 0;
                    dY = 1;
                }
                --curPoint.Y;
                if (--curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = -1;
                    dY = 0;
                }
                --curPoint.Y;
                if (curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = -1;
                    dY = -1;
                }
                ++curPoint.X;
                if (++curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = 1;
                    dY = -1;
                }
                ++curPoint.Y;
                ++curPoint.Y;
                if (curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = 1;
                    dY = 1;
                }
                --curPoint.X;
                if (--curPoint.X >= 0 && curPoint.X < 800 && curPoint.Y >= 0 && curPoint.Y < 600 && pfGrid[curPoint.X][curPoint.Y] != -1 && pfGrid[curPoint.X][curPoint.Y] < n)
                {
                    n = pfGrid[curPoint.X][curPoint.Y];
                    dX = -1;
                    dY = 1;
                }
                if (dX != deltaX || dY != deltaY)
                {
                    resultPoints.Push(to);
                    deltaX = dX;
                    deltaY = dY;
                }
                to.X += dX;
                to.Y += dY;
            }
            
            if (resultPoints.Count == 0)
            {
                resultPoints.Push(from);
            }

            var stackSize = -1;
            while (stackSize != resultPoints.Count)
            {
                stackSize = resultPoints.Count;
                for (var i = 2; i < resultPoints.Count; ++i)
                {
                    from.X = resultPoints.ElementAt(i - 2).X;
                    from.Y = resultPoints.ElementAt(i - 2).Y;
                    deltaX = resultPoints.ElementAt(i - 1).X;
                    deltaY = resultPoints.ElementAt(i - 1).Y;
                    to.X = resultPoints.ElementAt(i).X;
                    to.Y = resultPoints.ElementAt(i).Y;

                    var directPath = new System.Drawing.Drawing2D.GraphicsPath();
                    directPath.AddLine(new System.Drawing.Point(from.X, from.Y), new System.Drawing.Point(to.X, to.Y));
                    var lineBounds = directPath.GetBounds();

                    var line2d = new Line2D(new Point2D(from.X, from.Y), new Point2D(to.X, to.Y));
                    notFound = true;
                    for (curPoint.X = (int) lineBounds.X; curPoint.X < lineBounds.X + lineBounds.Width; ++curPoint.X)
                    {
                        for (curPoint.Y = (int)lineBounds.Y; curPoint.Y < lineBounds.Y + lineBounds.Height; ++curPoint.Y)
                        {
                            if (line2d.LineTo(new Point2D(curPoint.X, curPoint.Y), true).Length < 0.8)
                            {
                                notFound = (notFound && _wamData[curPoint.X][curPoint.Y]);
                            }
                        }
                    }

                    if (notFound)
                    { 
                        resultPoints = resultPoints.Where((source, index) => index != i - 1) as Stack<Point>;
                    }
                }
            }

            return resultPoints;
        }

        private Point GetNearestWamPoint(Point origin)
        {
            var minDistance = double.MaxValue;
            var newPoint = origin;

            if (_wamData[origin.X][origin.Y]) 
                return newPoint;

            for (var x = 0; x < WAM_WIDTH; ++x)
            for (var y = 0; y < WAM_HEIGHT; ++y)
            {
                if (_wamData[x][y])
                {
                    var myDistance = GetDistance(origin, new Point(x, y));
                    if (minDistance > myDistance)
                    {
                        minDistance = myDistance;
                        newPoint.X = x;
                        newPoint.Y = y;
                    }
                }
            }

            return newPoint;
        }

        private static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }
    }
}
