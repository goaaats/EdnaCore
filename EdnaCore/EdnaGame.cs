using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using EdnaCore.Data;
using EdnaCore.Data.Model;
using EdnaCore.Scenes;
using ImGuiNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SQLitePCL;
using WalkableAreaMap = EdnaCore.WAM.WalkableAreaMap;

namespace EdnaCore
{
    public class EdnaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ImGuiRenderer _imGuiRenderer;

        public const int EDNA_WINDOW_WIDTH = 800;
        public const int EDNA_WINDOW_HEIGHT = 600;

        public SpriteFont EdnaFont;

        public EdnaDbContext Database;

        public MusicManager Music = new MusicManager();

        public GameState State { get; set; }

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

        private GameScene _mainGameScene;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Debug.SpriteBatch = _spriteBatch;
            Debug.Graphics = _graphics;

            EdnaFont = Content.Load<SpriteFont>("EdnaFont");
            _debugPointMarkerTexture2D = Content.Load<Texture2D>("visual/gui/edna/cursor_a");

            Database = new EdnaDbContext();
            if (!File.Exists("Edna.db"))
                Database.ImportFromCsv(Path.Combine(Content.RootDirectory, "script", "de"));

            _mainGameScene = new MainMenuScene(this);
            _mainGameScene.LoadContent();

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

            _spriteBatch.Begin();

            if (_debugDrawWamView)
            {
                _debugCurrentWam?.DrawDebug();

                _spriteBatch.Draw(_debugPointMarkerTexture2D, new Vector2(_debugCurrentWamStartPos.X - 20, _debugCurrentWamStartPos.Y - 20), Color.White);
                _spriteBatch.DrawString(EdnaFont, "S", new Vector2(_debugCurrentWamStartPos.X, _debugCurrentWamStartPos.Y), Color.White);
                _spriteBatch.Draw(_debugPointMarkerTexture2D, new Vector2(_debugCurrentWamEndPos.X - 20, _debugCurrentWamEndPos.Y - 20), Color.White);
                _spriteBatch.DrawString(EdnaFont, "E", new Vector2(_debugCurrentWamEndPos.X, _debugCurrentWamEndPos.Y), Color.White);

                if (_debugCurrentWamPath != null)
                {
                    for (var i = 0; i < _debugCurrentWamPath.Count; i++)
                    {
                        var thisPoint = _debugCurrentWamPath.ElementAt(i);
                        _spriteBatch.Draw(_debugPointMarkerTexture2D, new Vector2(thisPoint.X, thisPoint.Y), Color.White);
                        _spriteBatch.DrawString(EdnaFont, i.ToString(), new Vector2(thisPoint.X + 20, thisPoint.Y + 20), Color.White);
                    }
                }
            }
            
            _spriteBatch.End();

            _imGuiRenderer.BeforeLayout(gameTime);

            // Draw our UI
            DrawDebugMenu();

            // Call AfterLayout now to finish up and draw all the things
            _imGuiRenderer.AfterLayout();

            base.Draw(gameTime);
        }

        public void LoadRoom(int roomId)
        {
            _mainGameScene = new EdnaRoomScene(roomId, this, null);
            _mainGameScene.LoadContent();
            State = GameState.Room;
        }

        private bool _debugDrawWamView;
        private string[] _debugWamList;
        private int _debugCurrentWamIndex = 0;
        private WalkableAreaMap _debugCurrentWam;
        private System.Numerics.Vector2 _debugCurrentWamStartPos, _debugCurrentWamEndPos;
        private Stack<Point> _debugCurrentWamPath;
        private Texture2D _debugPointMarkerTexture2D;
        private Texture2D _debugCurrentWamRoomTexture2D;
        private bool _debugIsPickingStart, _debugIsPickingEnd;

        private bool _debugDrawRoomView;
        private string[] _debugRoomList;
        private int _debugCurrentRoomIndex = 0;

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
                    ImGui.MenuItem("Draw EdnaRoom WAMs", string.Empty, ref Debug.DrawWalkableAreaMap);
                    if (ImGui.MenuItem("Open Viewer"))
                    {
                        _debugDrawWamView = true;
                        var wamList = new List<string>()
                        {
                            "None"
                        };
                        wamList.AddRange(Directory.GetFiles(Path.Combine(Content.RootDirectory, "map_converted")));
                        _debugWamList = wamList.ToArray();
                    }
                        

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Raum"))
                {
                    ImGui.MenuItem("Draw RaumObjekt rects", string.Empty, ref Debug.DrawRaumObjektRects);
                    if (ImGui.MenuItem("Load..."))
                    {
                        _debugDrawRoomView = true;
                        var roomList = new List<string>()
                        {
                            " -- Select -- "
                        };
                        roomList.AddRange(Database.Room.Select(x => $"{x.Bezeichnung} ({x.Id})"));
                        _debugRoomList = roomList.ToArray();
                    }


                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

            if (_debugDrawWamView && ImGui.Begin("WAM TEST", ref _debugDrawWamView))
            {
                ImGui.Combo("Select WAM", ref _debugCurrentWamIndex, _debugWamList, _debugWamList.Length);
                if (ImGui.Button("Load"))
                {
                    _debugCurrentWam = new WalkableAreaMap(File.ReadAllBytes(_debugWamList[_debugCurrentWamIndex]));
                    _debugCurrentWamPath = null;
                }

                ImGui.Separator();

                ImGui.InputFloat2("Start Pos", ref _debugCurrentWamStartPos);
                ImGui.SameLine();
                if (ImGui.Button("Pick"))
                    _debugIsPickingStart = true;

                ImGui.InputFloat2("End Pos", ref _debugCurrentWamEndPos);
                ImGui.SameLine();
                if (ImGui.Button("Pick##PickEnd"))
                    _debugIsPickingEnd = true;

                if (ImGui.Button("Find Path"))
                {
                    _debugCurrentWamPath = _debugCurrentWam?.FindPath(
                        new Point((int) _debugCurrentWamStartPos.X, (int) _debugCurrentWamStartPos.Y),
                        new Point((int) _debugCurrentWamEndPos.X, (int) _debugCurrentWamEndPos.Y));
                }
            }

            if (_debugDrawRoomView && ImGui.Begin("ROOM TEST", ref _debugDrawRoomView))
            {
                ImGui.Combo("Select Room", ref _debugCurrentRoomIndex, _debugRoomList, _debugRoomList.Length);

                if (_debugCurrentRoomIndex != 0)
                {
                    var curRoom = Database.Room.Include(x => x.WalkableAreaMap)
                        .AsEnumerable().ElementAt(_debugCurrentRoomIndex - 1);
                    ImGui.Text($"WAM: {curRoom.WalkableAreaMap.WamFile}({curRoom.WalkableAreaMap.Id})");
                    if (ImGui.Button("Load"))
                    {
                        LoadRoom(curRoom.Id);
                    }
                }
            }

            var mouseState = Mouse.GetState();
            if (mouseState.MiddleButton == ButtonState.Pressed)
            {
                if (_debugIsPickingStart)
                    _debugCurrentWamStartPos = new System.Numerics.Vector2(mouseState.X, mouseState.Y);

                if (_debugIsPickingEnd)
                    _debugCurrentWamEndPos = new System.Numerics.Vector2(mouseState.X, mouseState.Y);

                _debugIsPickingStart = false;
                _debugIsPickingEnd = false;
            }
        }
    }
}
