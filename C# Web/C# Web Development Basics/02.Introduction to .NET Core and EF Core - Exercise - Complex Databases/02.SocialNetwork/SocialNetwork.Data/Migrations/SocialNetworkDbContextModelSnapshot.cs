﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SocialNetwork.Data;
using SocialNetwork.Models.Enums;
using System;

namespace SocialNetwork.Data.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    partial class SocialNetworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialNetwork.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundColor")
                        .IsRequired();

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SocialNetwork.Models.Friendship", b =>
                {
                    b.Property<int>("FromUserId");

                    b.Property<int>("ToUserId");

                    b.HasKey("FromUserId", "ToUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.AlbumPicture", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("PictureId");

                    b.HasKey("AlbumId", "PictureId");

                    b.HasIndex("PictureId");

                    b.ToTable("AlbumPicture");
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.AlbumTag", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("TagId");

                    b.HasKey("AlbumId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AlbumTag");
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.OwnerAlbum", b =>
                {
                    b.Property<int>("OwnerId");

                    b.Property<int>("AlbumId");

                    b.HasKey("OwnerId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("OwnerAlbum");
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.ViewerAlbum", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("ViewerId");

                    b.HasKey("AlbumId", "ViewerId");

                    b.HasIndex("ViewerId");

                    b.ToTable("ViewerAlbum");
                });

            modelBuilder.Entity("SocialNetwork.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("SocialNetwork.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagValue");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastTimeLoggedIn");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("ProfilePicture")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("RegisteredOn");

                    b.Property<int>("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Models.Album", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.Friendship", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "FromUser")
                        .WithMany("FromFriends")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.User", "ToUser")
                        .WithMany("ToFriends")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.AlbumPicture", b =>
                {
                    b.HasOne("SocialNetwork.Models.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.Picture", "Picture")
                        .WithMany("Albums")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.AlbumTag", b =>
                {
                    b.HasOne("SocialNetwork.Models.Album", "Album")
                        .WithMany("Tags")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.Tag", "Tag")
                        .WithMany("Albums")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.OwnerAlbum", b =>
                {
                    b.HasOne("SocialNetwork.Models.Album", "Album")
                        .WithMany("Owners")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.User", "Owner")
                        .WithMany("SharedAlbums")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.Intermediate_tables.ViewerAlbum", b =>
                {
                    b.HasOne("SocialNetwork.Models.Album", "Album")
                        .WithMany("Viewers")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.User", "Viewer")
                        .WithMany()
                        .HasForeignKey("ViewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
