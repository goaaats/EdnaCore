using System;
using System.Collections.Generic;
using System.Text;
using EdnaCore.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace EdnaCore.Scenes
{
    class MainMenuScene : IGameScene, IDisposable
    {
        public IGameScene ParentScene { get; set; }

        private Song _mainMenuTrack;

        private Texture2D _menuBgTex;

        private SimpleEdnaButton _menuButtonNewGame;
        private SimpleEdnaButton _menuButtonPlay;
        private SimpleEdnaButton _menuButtonOptions;
        private SimpleEdnaButton _menuButtonLoad;
        private SimpleEdnaButton _menuButtonSave;

        private EdnaRoomScene _gameRoom;

        public void LoadContent(ContentManager content)
        {
            _mainMenuTrack = content.Load<Song>("audio/music/main_theme");
            MediaPlayer.Play(_mainMenuTrack);
            MediaPlayer.MediaStateChanged += MediaPlayerOnMediaStateChanged;

            _menuBgTex = content.Load<Texture2D>("visual/hintergrund/main_de");

            _menuButtonNewGame = new SimpleEdnaButton(content, "visual/gui/hauptmenue/de/b_neu", new Point(20, 300));

            _gameRoom = new EdnaRoomScene("");
            _gameRoom.LoadContent(content);
        }

        private void MediaPlayerOnMediaStateChanged(object? sender, EventArgs e)
        {
            MediaPlayer.Play(_mainMenuTrack);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_menuBgTex, Vector2.Zero, Color.White);

            if (_menuButtonNewGame.Draw(spriteBatch))
                MediaPlayer.Stop();

            _gameRoom.Draw(time, spriteBatch);

            spriteBatch.End();
        }

        public void Dispose()
        {
            MediaPlayer.MediaStateChanged -= MediaPlayerOnMediaStateChanged;
            MediaPlayer.Stop();

            _mainMenuTrack?.Dispose();
            _menuBgTex?.Dispose();
        }
    }
}
