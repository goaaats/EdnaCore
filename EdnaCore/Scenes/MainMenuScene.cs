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
    class MainMenuScene : GameScene, IDisposable
    {
        public MainMenuScene(EdnaGame game, GameScene parentScene = null) : base(game, parentScene)
        {
        }

        private Song _mainMenuTrack;

        private Texture2D _menuBgTex;

        private SimpleEdnaButton _menuButtonNewGame;
        private SimpleEdnaButton _menuButtonPlay;
        private SimpleEdnaButton _menuButtonOptions;
        private SimpleEdnaButton _menuButtonLoad;
        private SimpleEdnaButton _menuButtonSave;

        public override void LoadContent()
        {
            _mainMenuTrack = Game.Content.Load<Song>("audio/music/main_theme");
            Game.Music.PlaySong(_mainMenuTrack);

            _menuBgTex = Game.Content.Load<Texture2D>("visual/hintergrund/main_de");

            _menuButtonNewGame = new SimpleEdnaButton(Game.Content, "visual/gui/hauptmenue/de/b_neu", new Point(20, 300));
        }

        public override void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_menuBgTex, Vector2.Zero, Color.White);

            if (_menuButtonNewGame.Draw(spriteBatch))
                Game.LoadRoom(100101);
                
            spriteBatch.DrawString(Game.EdnaFont, "EDNA CORE", new Vector2(448, 526), Color.Black);

            spriteBatch.End();
        }

        public void Dispose()
        {
            Game.Music.Stop();

            _mainMenuTrack?.Dispose();
            _menuBgTex?.Dispose();
        }
    }
}
