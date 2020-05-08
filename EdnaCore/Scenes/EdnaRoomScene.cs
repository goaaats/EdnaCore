using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EdnaCore.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using WalkableAreaMap = EdnaCore.WAM.WalkableAreaMap;

namespace EdnaCore.Scenes
{
    class EdnaRoomScene : GameScene
    {
        private readonly Raum _roomData;

        private WalkableAreaMap _walkableAreaMap;

        private Texture2D _backgroundTexture2D;
        private Song _music;

        public EdnaRoomScene(int roomId, EdnaGame game, GameScene parentScene = null) : base(game, parentScene)
        {
            _roomData = game.Database.Room.Include(x => x.WalkableAreaMap).First(x => x.Id == roomId);
        }

        public override void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_backgroundTexture2D, Vector2.Zero, Color.White);

            if (Debug.DrawWalkableAreaMap)
                _walkableAreaMap?.DrawDebug();

            spriteBatch.End();
        }

        public override void LoadContent()
        {
            _walkableAreaMap = new WalkableAreaMap(File.ReadAllBytes(Path.Combine(Game.Content.RootDirectory, "map_converted", _roomData.WalkableAreaMap.WamFile + "c")));

            _backgroundTexture2D =
                Game.Content.Load<Texture2D>("visual/" + _roomData.BildDatei.Substring(0, _roomData.BildDatei.Length - 4));
            _music = Game.Content.Load<Song>("audio/" + _roomData.MusikDatei.Substring(1));

            Game.Music.PlaySong(_music);
        }
    }
}
