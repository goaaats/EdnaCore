using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EdnaCore.WAM;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EdnaCore.Scenes
{
    class EdnaRoomScene : IGameScene
    {
        private readonly string _roomName;
        public IGameScene ParentScene { get; set; }

        private WalkableAreaMap _walkableAreaMap;

        public EdnaRoomScene(string roomName)
        {
            _roomName = roomName;
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            if (Debug.DrawWalkableAreaMap)
                _walkableAreaMap?.DrawDebug();
        }

        public void LoadContent(ContentManager content)
        {
            _walkableAreaMap = new WalkableAreaMap(File.ReadAllBytes(Path.Combine(content.RootDirectory, "map_converted/1001.wamc")));
        }
    }
}
