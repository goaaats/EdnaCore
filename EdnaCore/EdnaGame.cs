using System.Diagnostics;
using EdnaCore.Scenes;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EdnaCore
{
    public class EdnaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ImGuiRenderer _imGuiRenderer;

        public const int EDNA_WINDOW_WIDTH = 800;
        public const int EDNA_WINDOW_HEIGHT = 600;

        public EdnaGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = EDNA_WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = EDNA_WINDOW_WIDTH;
            _graphics.PreferMultiSampling = true;
            _graphics.ApplyChanges();

            _imGuiRenderer = new ImGuiRenderer(this);
            _imGuiRenderer.RebuildFontAtlas();

            base.Initialize();
        }

        private readonly IGameScene _mainGameScene = new BaseScene();

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Debug.SpriteBatch = _spriteBatch;
            Debug.Graphics = _graphics;

            _mainGameScene.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _mainGameScene.Draw(gameTime, _spriteBatch);

            _imGuiRenderer.BeforeLayout(gameTime);

            // Draw our UI
            DrawDebugMenu();

            // Call AfterLayout now to finish up and draw all the things
            _imGuiRenderer.AfterLayout();

            base.Draw(gameTime);
        }

        protected virtual void DrawDebugMenu()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    ImGui.MenuItem("Draw button rects", string.Empty, ref Debug.DrawButtonRects);

                    if (ImGui.MenuItem("Toggle Fullscreen"))
                    {
                        _graphics.ToggleFullScreen();
                    }

                    if (ImGui.MenuItem("Kill"))
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("WAM"))
                {
                    ImGui.MenuItem("Draw WAMs", string.Empty, ref Debug.DrawWalkableAreaMap);
                    ImGui.MenuItem("Open Editor");
                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }
        }
    }
}
