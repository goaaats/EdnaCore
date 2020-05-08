﻿// <auto-generated />
using System;
using EdnaCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EdnaCore.Migrations
{
    [DbContext(typeof(EdnaDbContext))]
    partial class EdnaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2");

            modelBuilder.Entity("EdnaCore.Data.Model.Animationsbild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbweichendeAnzeigeDauer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BildDatei")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BildfolgeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BildfolgeId");

                    b.ToTable("AnimationFrame");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Ausgang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharakterBlickRichtung")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RaumObjektInteraktionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WalkInPointX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WalkInPointY")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ZielRaumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaumObjektInteraktionId");

                    b.HasIndex("ZielRaumId");

                    b.ToTable("Exit");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.BenutzeMit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("InventarObjektId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumObjektId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InventarObjektId");

                    b.HasIndex("RaumObjektId");

                    b.ToTable("UseWith");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Bildfolge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anzeigedauer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Loop")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FrameSet");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.CharacterAnimationSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AktionsmodusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HintenBildfolgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LinksBildfolgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RechtsBildfolgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VorneBildfolgeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HintenBildfolgeId");

                    b.HasIndex("LinksBildfolgeId");

                    b.HasIndex("RechtsBildfolgeId");

                    b.HasIndex("VorneBildfolgeId");

                    b.ToTable("CharacterAnimationSet");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.ChoiceListeEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Aktiv")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuswahlNummer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuswahlText")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ChoiceList");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.InventarBenutzeMit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("InventarObjekt1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InventarObjekt2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InventarObjekt1Id");

                    b.HasIndex("InventarObjekt2Id");

                    b.ToTable("InventoryUseWith");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.InventarObjekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnsehenSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BenutzenSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<string>("DefaultAktion")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuiId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconDatei")
                        .HasColumnType("TEXT");

                    b.Property<int>("InventarPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RedenMitSkriptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("InventoryObject");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.NSC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BaseYatFullScale")
                        .HasColumnType("REAL");

                    b.Property<double>("BaseYatZeroScale")
                        .HasColumnType("REAL");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CharacterAnimationSetId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Font")
                        .HasColumnType("TEXT");

                    b.Property<double>("HSpeed")
                        .HasColumnType("REAL");

                    b.Property<int?>("RaumObjektId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VSpeed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CharacterAnimationSetId");

                    b.HasIndex("RaumObjektId");

                    b.ToTable("NPC");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Raum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BaseYatFullScale")
                        .HasColumnType("REAL");

                    b.Property<double>("BaseYatZeroScale")
                        .HasColumnType("REAL");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<string>("BildDatei")
                        .HasColumnType("TEXT");

                    b.Property<int>("CharacterAnimationSetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuiId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("HSpeed")
                        .HasColumnType("REAL");

                    b.Property<string>("MusikDatei")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TimerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VSpeed")
                        .HasColumnType("REAL");

                    b.Property<int?>("WalkableAreaMapId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TimerId");

                    b.HasIndex("WalkableAreaMapId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aktiv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<string>("BildDatei")
                        .HasColumnType("TEXT");

                    b.Property<int>("PosX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosZ")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaumId");

                    b.ToTable("RoomObject");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjektDarstellung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaselineEndX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaselineEndY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaselineStartX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaselineStartY")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BildfolgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumObjektId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BildfolgeId");

                    b.HasIndex("RaumObjektId");

                    b.ToTable("RoomObjectDisplay");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjektInteraktion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnsehenSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BenutzenSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BezeichnungOMO")
                        .HasColumnType("TEXT");

                    b.Property<string>("DefaultAktion")
                        .HasColumnType("TEXT");

                    b.Property<int>("NehmenSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumObjektId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RedenMitSkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StandByBlickrichtung")
                        .HasColumnType("TEXT");

                    b.Property<int>("WalkToX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WalkToY")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaumObjektId");

                    b.ToTable("RoomObjectInteraction");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Skript", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kommentar")
                        .HasColumnType("TEXT");

                    b.Property<string>("SkriptAktion")
                        .HasColumnType("TEXT");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Zeilennummer")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Script");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Timer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aktiv")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dauer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Timer");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<string>("IconDatei")
                        .HasColumnType("TEXT");

                    b.Property<int>("InventarPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumObjektId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkriptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TopicLeistenPosition")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaumObjektId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.WalkableAreaMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("WamFile")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WalkableAreaMap");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Animationsbild", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "Bildfolge")
                        .WithMany()
                        .HasForeignKey("BildfolgeId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Ausgang", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.RaumObjektInteraktion", "RaumObjektInteraktion")
                        .WithMany()
                        .HasForeignKey("RaumObjektInteraktionId");

                    b.HasOne("EdnaCore.Data.Model.Raum", "ZielRaum")
                        .WithMany()
                        .HasForeignKey("ZielRaumId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.BenutzeMit", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.InventarObjekt", "InventarObjekt")
                        .WithMany()
                        .HasForeignKey("InventarObjektId");

                    b.HasOne("EdnaCore.Data.Model.RaumObjekt", "RaumObjekt")
                        .WithMany()
                        .HasForeignKey("RaumObjektId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.CharacterAnimationSet", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "HintenBildfolge")
                        .WithMany()
                        .HasForeignKey("HintenBildfolgeId");

                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "LinksBildfolge")
                        .WithMany()
                        .HasForeignKey("LinksBildfolgeId");

                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "RechtsBildfolge")
                        .WithMany()
                        .HasForeignKey("RechtsBildfolgeId");

                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "VorneBildfolge")
                        .WithMany()
                        .HasForeignKey("VorneBildfolgeId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.InventarBenutzeMit", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.InventarObjekt", "InventarObjekt1")
                        .WithMany()
                        .HasForeignKey("InventarObjekt1Id");

                    b.HasOne("EdnaCore.Data.Model.InventarObjekt", "InventarObjekt2")
                        .WithMany()
                        .HasForeignKey("InventarObjekt2Id");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.NSC", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.CharacterAnimationSet", "CharacterAnimationSet")
                        .WithMany()
                        .HasForeignKey("CharacterAnimationSetId");

                    b.HasOne("EdnaCore.Data.Model.RaumObjekt", "RaumObjekt")
                        .WithMany()
                        .HasForeignKey("RaumObjektId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Raum", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.Timer", "Timer")
                        .WithMany()
                        .HasForeignKey("TimerId");

                    b.HasOne("EdnaCore.Data.Model.WalkableAreaMap", "WalkableAreaMap")
                        .WithMany()
                        .HasForeignKey("WalkableAreaMapId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjekt", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.Raum", "Raum")
                        .WithMany()
                        .HasForeignKey("RaumId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjektDarstellung", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.Bildfolge", "Bildfolge")
                        .WithMany()
                        .HasForeignKey("BildfolgeId");

                    b.HasOne("EdnaCore.Data.Model.RaumObjekt", "RaumObjekt")
                        .WithMany()
                        .HasForeignKey("RaumObjektId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.RaumObjektInteraktion", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.RaumObjekt", "RaumObjekt")
                        .WithMany()
                        .HasForeignKey("RaumObjektId");
                });

            modelBuilder.Entity("EdnaCore.Data.Model.Topic", b =>
                {
                    b.HasOne("EdnaCore.Data.Model.RaumObjekt", "RaumObjekt")
                        .WithMany()
                        .HasForeignKey("RaumObjektId");
                });
#pragma warning restore 612, 618
        }
    }
}
