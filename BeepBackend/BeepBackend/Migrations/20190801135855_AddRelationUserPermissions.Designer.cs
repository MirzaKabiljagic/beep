﻿// <auto-generated />
using System;
using BeepBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeepBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190801135855_AddRelationUserPermissions")]
    partial class AddRelationUserPermissions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeepBackend.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleGroupFk");

                    b.Property<string>("Barcode");

                    b.Property<bool>("HasLifetime");

                    b.Property<string>("Name");

                    b.Property<int>("TypicalLifetime");

                    b.HasKey("Id");

                    b.HasIndex("ArticleGroupFk");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("BeepBackend.Models.ArticleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ArticleGroups");
                });

            modelBuilder.Entity("BeepBackend.Models.ArticleStore", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("StoreId");

                    b.HasKey("ArticleId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("ArticleStore");
                });

            modelBuilder.Entity("BeepBackend.Models.ArticleUserSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOnStock");

                    b.Property<int>("ArticleFk");

                    b.Property<bool>("IsOpened");

                    b.Property<int>("KeppStockMode");

                    b.Property<DateTime>("OpenedOn");

                    b.Property<int>("StockAmount");

                    b.HasKey("Id");

                    b.HasIndex("ArticleFk");

                    b.ToTable("ArticleUserSettings");
                });

            modelBuilder.Entity("BeepBackend.Models.BeepEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("BeepBackend.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanView");

                    b.Property<bool>("CheckIn");

                    b.Property<bool>("CheckOut");

                    b.Property<bool>("EditArticleSettings");

                    b.Property<bool>("Invite");

                    b.Property<bool>("IsOwner");

                    b.Property<bool>("RemoveMember");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("BeepBackend.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("BeepBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeepBackend.Models.UserArticle", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ArticleId");

                    b.HasKey("UserId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("UserArticles");
                });

            modelBuilder.Entity("BeepBackend.Models.Article", b =>
                {
                    b.HasOne("BeepBackend.Models.ArticleGroup", "ArticleGroup")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleGroupFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeepBackend.Models.ArticleStore", b =>
                {
                    b.HasOne("BeepBackend.Models.Article", "Article")
                        .WithMany("Stores")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeepBackend.Models.Store", "Store")
                        .WithMany("Articles")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeepBackend.Models.ArticleUserSetting", b =>
                {
                    b.HasOne("BeepBackend.Models.Article", "Article")
                        .WithMany("ArticleUserSettings")
                        .HasForeignKey("ArticleFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeepBackend.Models.BeepEnvironment", b =>
                {
                    b.HasOne("BeepBackend.Models.User", "User")
                        .WithMany("Environments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeepBackend.Models.Permission", b =>
                {
                    b.HasOne("BeepBackend.Models.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeepBackend.Models.UserArticle", b =>
                {
                    b.HasOne("BeepBackend.Models.Article", "Article")
                        .WithMany("UserArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BeepBackend.Models.User", "User")
                        .WithMany("UserArticles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
