﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DIO.Media.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("DIO.Media.src.Entity.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DIO.Media.src.Entity.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Excluded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Medias");

                    b.HasDiscriminator().HasValue("Media");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DIO.Media.src.Entity.Movie", b =>
                {
                    b.HasBaseType("DIO.Media.src.Entity.Media");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("DIO.Media.src.Entity.Serie", b =>
                {
                    b.HasBaseType("DIO.Media.src.Entity.Media");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("DIO.Media.src.Entity.Media", b =>
                {
                    b.HasOne("DIO.Media.src.Entity.Genre", null)
                        .WithMany("Medias")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DIO.Media.src.Entity.Genre", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
