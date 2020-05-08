using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EdnaCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EdnaCore.Data
{
    public class EdnaDbContext : DbContext
    {
        public DbSet<WalkableAreaMap> WalkableAreaMap { get; set; }
        public DbSet<Skript> Script { get; set; }
        public DbSet<Bildfolge> FrameSet { get; set; }
        public DbSet<CharacterAnimationSet> CharacterAnimationSet { get; set; }
        public DbSet<ChoiceListeEntry> ChoiceList { get; set; }
        public DbSet<Timer> Timer { get; set; }
        public DbSet<Raum> Room { get; set; }
        public DbSet<RaumObjekt> RoomObject { get; set; }
        public DbSet<RaumObjektInteraktion> RoomObjectInteraction { get; set; }
        public DbSet<InventarObjekt> InventoryObject { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<InventarBenutzeMit> InventoryUseWith { get; set; }
        public DbSet<Ausgang> Exit { get; set; }
        public DbSet<BenutzeMit> UseWith { get; set; }
        public DbSet<Animationsbild> AnimationFrame { get; set; }
        public DbSet<RaumObjektDarstellung> RoomObjectDisplay { get; set; }
        public DbSet<NSC> NPC { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=Edna.db;")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WalkableAreaMap>().ToTable("WalkableAreaMap");
            modelBuilder.Entity<Skript>().ToTable("Script");
            modelBuilder.Entity<Bildfolge>().ToTable("FrameSet");
            modelBuilder.Entity<CharacterAnimationSet>().ToTable("CharacterAnimationSet");
            modelBuilder.Entity<ChoiceListeEntry>().ToTable("ChoiceList");
            modelBuilder.Entity<Timer>().ToTable("Timer");
            modelBuilder.Entity<Raum>().ToTable("Room");
            modelBuilder.Entity<RaumObjekt>().ToTable("RoomObject");
            modelBuilder.Entity<RaumObjektInteraktion>().ToTable("RoomObjectInteraction");
            modelBuilder.Entity<InventarObjekt>().ToTable("InventoryObject");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<InventarBenutzeMit>().ToTable("InventoryUseWith");
            modelBuilder.Entity<Ausgang>().ToTable("Exit");
            modelBuilder.Entity<BenutzeMit>().ToTable("UseWith");
            modelBuilder.Entity<Animationsbild>().ToTable("AnimationFrame");
            modelBuilder.Entity<RaumObjektDarstellung>().ToTable("RoomObjectDisplay");
            modelBuilder.Entity<NSC>().ToTable("NPC");
        }

        public void ImportFromCsv(string path)
        {
            Database.EnsureDeleted();
            Database.Migrate();

            #region WalkableAreaMap

            var walkableAreaMapCsv = ParseCsv(Path.Combine(path, "walkableareamap.csv"));

            foreach (var result in walkableAreaMapCsv)
            {
                if (result.Length != 3)
                    continue;

                WalkableAreaMap.Add(new WalkableAreaMap
                {
                    Id = int.Parse(result[0]),
                    WamFile = result[2]
                });
            }

            #endregion

            #region Script

            var scriptCsv = ParseCsv(Path.Combine(path, "skript.csv"));

            foreach (var result in scriptCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 5, "SKRIPT column count failed?");

                if (result.Length != 4)
                    continue;

                Script.Add(new Skript()
                {
                    SkriptId = int.Parse(result[0]),
                    Zeilennummer = int.Parse(result[1]),
                    SkriptAktion = result[2],
                    Kommentar = result[3]
                });
            }

            #endregion

            #region FrameSet

            var frameSetCsv = ParseCsv(Path.Combine(path, "bildfolge.csv"));

            foreach (var result in frameSetCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 4, "BILDFOLGE column count failed?");

                if (result.Length != 4)
                    continue;

                FrameSet.Add(new Bildfolge()
                {
                    Id = int.Parse(result[0]),
                    Bezeichnung = result[1],
                    Anzeigedauer = int.Parse(result[2]),
                    Loop = bool.Parse(result[3])
                });

                System.Diagnostics.Debug.Assert(!FrameSet.Any(x => x.Id == int.Parse(result[0])), "duplicate BILDFOLGE?");
            }

            #endregion

            SaveChanges();

            #region CharacterAnimationSet

            var characterAnimationSetCsv = ParseCsv(Path.Combine(path, "characteranimationset.csv"));

            foreach (var result in characterAnimationSetCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 7, "CHARACTERANIMATIONSET column count failed?");

                if (result.Length != 7)
                    continue;

                var thisSet = new CharacterAnimationSet()
                {
                    SetId = int.Parse(result[0]),
                    AktionsmodusId = int.Parse(result[1]),
                    Bezeichnung = result[2],
                    LinksBildfolge = FrameSet.Find(int.Parse(result[3])),
                    RechtsBildfolge = FrameSet.Find(int.Parse(result[4])),
                    VorneBildfolge = FrameSet.Find(int.Parse(result[5])),
                    HintenBildfolge = FrameSet.Find(int.Parse(result[6])),
                };

                CharacterAnimationSet.Add(thisSet);

                // There are various CAS with null animations
                //System.Diagnostics.Debug.Assert(thisSet.LinksBildfolge != null && thisSet.RechtsBildfolge != null && thisSet.VorneBildfolge != null && thisSet.HintenBildfolge != null, $"CHARACTERANIMATIONSET {thisSet.Bezeichnung} has null bildfolge?");
            }

            #endregion

            #region ChoiceList

            var choiceListCsv = ParseCsv(Path.Combine(path, "choiceliste.csv"));

            foreach (var result in choiceListCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 5, "CHOICELISTE column count failed?");

                if (result.Length != 5)
                    continue;

                var thisSet = new ChoiceListeEntry()
                {
                    ChoiceId = int.Parse(result[0]),
                    AuswahlNummer = int.Parse(result[1]),
                    Aktiv = bool.Parse(result[2]),
                    AuswahlText = result[3],
                    SkriptId = int.Parse(result[4])

                };

                ChoiceList.Add(thisSet);
            }

            #endregion

            #region Timer

            var timerCsv = ParseCsv(Path.Combine(path, "timer.csv"));

            foreach (var result in timerCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 4, "TIMER column count failed?");

                if (result.Length != 4)
                    continue;

                Timer.Add(new Timer()
                {
                    Id = int.Parse(result[0]),
                    SkriptId = int.Parse(result[1]),
                    Dauer = int.Parse(result[2]),
                    Aktiv = bool.Parse(result[3])
                });
            }

            #endregion

            #region ChoiceList

            var roomCsv = ParseCsv(Path.Combine(path, "raum.csv"));

            foreach (var result in roomCsv)
            {
                System.Diagnostics.Debug.Assert(result.Length <= 13, "RAUM column count failed?");

                if (result.Length > 13 || result.Length < 12)
                    continue;

                var thisRoom = new Raum
                {
                    Id = int.Parse(result[0]),
                    Bezeichnung = result[1],
                    BildDatei = result[2],
                    MusikDatei = result[3],
                    WalkableAreaMap = WalkableAreaMap.Find(int.Parse(result[4])),
                    VSpeed = ParseDouble(result[5]),
                    HSpeed = ParseDouble(result[6]),
                    BaseYatZeroScale = ParseDouble(result[7]),
                    BaseYatFullScale = ParseDouble(result[8]),
                    GuiId = int.Parse(result[9]),
                    CharacterAnimationSetId = int.Parse(result[10]),
                    Timer = Timer.Find(int.Parse(result[11]))
                };

                Room.Add(thisRoom);
            }

            #endregion

            SaveChanges();
        }

        private static double ParseDouble(string input)
        {
            if (input[0] == '.')
                input = "0" + input;

            return double.Parse(input);
        }

        private static IEnumerable<string[]> ParseCsv(string path)
        {
            var csvText = File.ReadAllText(path);
            var csvLines = Regex.Split(csvText, "\r\n|\r|\n");

            var result = new string[csvLines.Length][];

            for (var i = 0; i < csvLines.Length; i++)
            {
                result[i] = csvLines[i].Split(';');
            }

            return result;
        }
    }
}
