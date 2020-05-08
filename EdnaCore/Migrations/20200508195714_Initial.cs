using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdnaCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChoiceList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuswahlNummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Aktiv = table.Column<bool>(type: "INTEGER", nullable: false),
                    AuswahlText = table.Column<string>(type: "TEXT", nullable: true),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrameSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    Anzeigedauer = table.Column<int>(type: "INTEGER", nullable: false),
                    Loop = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuiId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    IconDatei = table.Column<string>(type: "TEXT", nullable: true),
                    InventarPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultAktion = table.Column<string>(type: "TEXT", nullable: true),
                    AnsehenSkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    BenutzenSkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    RedenMitSkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Script",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    Zeilennummer = table.Column<int>(type: "INTEGER", nullable: false),
                    SkriptAktion = table.Column<string>(type: "TEXT", nullable: true),
                    Kommentar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Script", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dauer = table.Column<int>(type: "INTEGER", nullable: false),
                    Aktiv = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkableAreaMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WamFile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkableAreaMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimationFrame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BildfolgeId = table.Column<int>(type: "INTEGER", nullable: true),
                    BildDatei = table.Column<string>(type: "TEXT", nullable: true),
                    AbweichendeAnzeigeDauer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationFrame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationFrame_FrameSet_BildfolgeId",
                        column: x => x.BildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAnimationSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SetId = table.Column<int>(type: "INTEGER", nullable: false),
                    AktionsmodusId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    LinksBildfolgeId = table.Column<int>(type: "INTEGER", nullable: true),
                    RechtsBildfolgeId = table.Column<int>(type: "INTEGER", nullable: true),
                    VorneBildfolgeId = table.Column<int>(type: "INTEGER", nullable: true),
                    HintenBildfolgeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAnimationSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAnimationSet_FrameSet_HintenBildfolgeId",
                        column: x => x.HintenBildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterAnimationSet_FrameSet_LinksBildfolgeId",
                        column: x => x.LinksBildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterAnimationSet_FrameSet_RechtsBildfolgeId",
                        column: x => x.RechtsBildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterAnimationSet_FrameSet_VorneBildfolgeId",
                        column: x => x.VorneBildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryUseWith",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InventarObjekt1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    InventarObjekt2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryUseWith", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryUseWith_InventoryObject_InventarObjekt1Id",
                        column: x => x.InventarObjekt1Id,
                        principalTable: "InventoryObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryUseWith_InventoryObject_InventarObjekt2Id",
                        column: x => x.InventarObjekt2Id,
                        principalTable: "InventoryObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    BildDatei = table.Column<string>(type: "TEXT", nullable: true),
                    MusikDatei = table.Column<string>(type: "TEXT", nullable: true),
                    WalkableAreaMapId = table.Column<int>(type: "INTEGER", nullable: true),
                    VSpeed = table.Column<double>(type: "REAL", nullable: false),
                    HSpeed = table.Column<double>(type: "REAL", nullable: false),
                    BaseYatZeroScale = table.Column<double>(type: "REAL", nullable: false),
                    BaseYatFullScale = table.Column<double>(type: "REAL", nullable: false),
                    GuiId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterAnimationSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Timer_TimerId",
                        column: x => x.TimerId,
                        principalTable: "Timer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_WalkableAreaMap_WalkableAreaMapId",
                        column: x => x.WalkableAreaMapId,
                        principalTable: "WalkableAreaMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    RaumId = table.Column<int>(type: "INTEGER", nullable: true),
                    PosX = table.Column<int>(type: "INTEGER", nullable: false),
                    PosY = table.Column<int>(type: "INTEGER", nullable: false),
                    PosZ = table.Column<int>(type: "INTEGER", nullable: false),
                    BildDatei = table.Column<string>(type: "TEXT", nullable: true),
                    Aktiv = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomObject_Room_RaumId",
                        column: x => x.RaumId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NPC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaumObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterAnimationSetId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    Font = table.Column<string>(type: "TEXT", nullable: true),
                    VSpeed = table.Column<double>(type: "REAL", nullable: false),
                    HSpeed = table.Column<double>(type: "REAL", nullable: false),
                    BaseYatZeroScale = table.Column<double>(type: "REAL", nullable: false),
                    BaseYatFullScale = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPC_CharacterAnimationSet_CharacterAnimationSetId",
                        column: x => x.CharacterAnimationSetId,
                        principalTable: "CharacterAnimationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NPC_RoomObject_RaumObjektId",
                        column: x => x.RaumObjektId,
                        principalTable: "RoomObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomObjectDisplay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaumObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    BildfolgeId = table.Column<int>(type: "INTEGER", nullable: true),
                    BaselineStartX = table.Column<int>(type: "INTEGER", nullable: false),
                    BaselineStartY = table.Column<int>(type: "INTEGER", nullable: false),
                    BaselineEndX = table.Column<int>(type: "INTEGER", nullable: false),
                    BaselineEndY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomObjectDisplay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomObjectDisplay_FrameSet_BildfolgeId",
                        column: x => x.BildfolgeId,
                        principalTable: "FrameSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomObjectDisplay_RoomObject_RaumObjektId",
                        column: x => x.RaumObjektId,
                        principalTable: "RoomObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomObjectInteraction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaumObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    BezeichnungOMO = table.Column<string>(type: "TEXT", nullable: true),
                    WalkToX = table.Column<int>(type: "INTEGER", nullable: false),
                    WalkToY = table.Column<int>(type: "INTEGER", nullable: false),
                    StandByBlickrichtung = table.Column<string>(type: "TEXT", nullable: true),
                    DefaultAktion = table.Column<string>(type: "TEXT", nullable: true),
                    AnsehenSkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    BenutzenSkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    NehmenSkriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    RedenMitSkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomObjectInteraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomObjectInteraction_RoomObject_RaumObjektId",
                        column: x => x.RaumObjektId,
                        principalTable: "RoomObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaumObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: true),
                    IconDatei = table.Column<string>(type: "TEXT", nullable: true),
                    InventarPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    TopicLeistenPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_RoomObject_RaumObjektId",
                        column: x => x.RaumObjektId,
                        principalTable: "RoomObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UseWith",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InventarObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    RaumObjektId = table.Column<int>(type: "INTEGER", nullable: true),
                    SkriptId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseWith", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UseWith_InventoryObject_InventarObjektId",
                        column: x => x.InventarObjektId,
                        principalTable: "InventoryObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UseWith_RoomObject_RaumObjektId",
                        column: x => x.RaumObjektId,
                        principalTable: "RoomObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaumObjektInteraktionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZielRaumId = table.Column<int>(type: "INTEGER", nullable: true),
                    WalkInPointX = table.Column<int>(type: "INTEGER", nullable: false),
                    WalkInPointY = table.Column<int>(type: "INTEGER", nullable: false),
                    CharakterBlickRichtung = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exit_Room_ZielRaumId",
                        column: x => x.ZielRaumId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exit_RoomObjectInteraction_RaumObjektInteraktionId",
                        column: x => x.RaumObjektInteraktionId,
                        principalTable: "RoomObjectInteraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationFrame_BildfolgeId",
                table: "AnimationFrame",
                column: "BildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAnimationSet_HintenBildfolgeId",
                table: "CharacterAnimationSet",
                column: "HintenBildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAnimationSet_LinksBildfolgeId",
                table: "CharacterAnimationSet",
                column: "LinksBildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAnimationSet_RechtsBildfolgeId",
                table: "CharacterAnimationSet",
                column: "RechtsBildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAnimationSet_VorneBildfolgeId",
                table: "CharacterAnimationSet",
                column: "VorneBildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exit_RaumObjektInteraktionId",
                table: "Exit",
                column: "RaumObjektInteraktionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exit_ZielRaumId",
                table: "Exit",
                column: "ZielRaumId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryUseWith_InventarObjekt1Id",
                table: "InventoryUseWith",
                column: "InventarObjekt1Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryUseWith_InventarObjekt2Id",
                table: "InventoryUseWith",
                column: "InventarObjekt2Id");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_CharacterAnimationSetId",
                table: "NPC",
                column: "CharacterAnimationSetId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_RaumObjektId",
                table: "NPC",
                column: "RaumObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TimerId",
                table: "Room",
                column: "TimerId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_WalkableAreaMapId",
                table: "Room",
                column: "WalkableAreaMapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomObject_RaumId",
                table: "RoomObject",
                column: "RaumId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomObjectDisplay_BildfolgeId",
                table: "RoomObjectDisplay",
                column: "BildfolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomObjectDisplay_RaumObjektId",
                table: "RoomObjectDisplay",
                column: "RaumObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomObjectInteraction_RaumObjektId",
                table: "RoomObjectInteraction",
                column: "RaumObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_RaumObjektId",
                table: "Topic",
                column: "RaumObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_UseWith_InventarObjektId",
                table: "UseWith",
                column: "InventarObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_UseWith_RaumObjektId",
                table: "UseWith",
                column: "RaumObjektId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationFrame");

            migrationBuilder.DropTable(
                name: "ChoiceList");

            migrationBuilder.DropTable(
                name: "Exit");

            migrationBuilder.DropTable(
                name: "InventoryUseWith");

            migrationBuilder.DropTable(
                name: "NPC");

            migrationBuilder.DropTable(
                name: "RoomObjectDisplay");

            migrationBuilder.DropTable(
                name: "Script");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "UseWith");

            migrationBuilder.DropTable(
                name: "RoomObjectInteraction");

            migrationBuilder.DropTable(
                name: "CharacterAnimationSet");

            migrationBuilder.DropTable(
                name: "InventoryObject");

            migrationBuilder.DropTable(
                name: "RoomObject");

            migrationBuilder.DropTable(
                name: "FrameSet");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Timer");

            migrationBuilder.DropTable(
                name: "WalkableAreaMap");
        }
    }
}
