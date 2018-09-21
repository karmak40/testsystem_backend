﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testsystem.context;

namespace testsystem.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20180918131433_ChangeStructure1")]
    partial class ChangeStructure1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("testsystem.Models.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidatId");

                    b.Property<string>("Content");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("CandidatId");

                    b.HasIndex("TestId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Candidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("ExpiredDate");

                    b.Property<long>("InvitationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Candidats");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<long>("CloseDate");

                    b.Property<string>("CompanyInfo");

                    b.Property<string>("Instruction");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<long>("OpenDate");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerId");

                    b.Property<int>("Grade");

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<int?>("TestId");

                    b.Property<int?>("ViewerId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("TestId");

                    b.HasIndex("ViewerId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<int?>("PositionId");

                    b.Property<long>("Time");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Viewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("InvitationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Number")
                        .HasMaxLength(50);

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Viewers");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Answer", b =>
                {
                    b.HasOne("testsystem.Models.Entities.Candidat", "Candidat")
                        .WithMany("Answers")
                        .HasForeignKey("CandidatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("testsystem.Models.Entities.Test", "Test")
                        .WithMany("Answers")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("testsystem.Models.Entities.Candidat", b =>
                {
                    b.HasOne("testsystem.Models.Entities.Position", "Position")
                        .WithMany("Candidats")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Rating", b =>
                {
                    b.HasOne("testsystem.Models.Entities.Answer", "Answer")
                        .WithMany("Rating")
                        .HasForeignKey("AnswerId");

                    b.HasOne("testsystem.Models.Entities.Test")
                        .WithMany("Rating")
                        .HasForeignKey("TestId");

                    b.HasOne("testsystem.Models.Entities.Viewer", "Viewer")
                        .WithMany("Rating")
                        .HasForeignKey("ViewerId");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Test", b =>
                {
                    b.HasOne("testsystem.Models.Entities.Position", "Position")
                        .WithMany("Tests")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("testsystem.Models.Entities.Viewer", b =>
                {
                    b.HasOne("testsystem.Models.Entities.Position", "Position")
                        .WithMany("Viewers")
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}