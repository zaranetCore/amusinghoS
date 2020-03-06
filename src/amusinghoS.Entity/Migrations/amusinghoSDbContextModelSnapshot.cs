﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using amusinghoS.EntityData;

namespace amusinghoS.EntityData.Migrations
{
    [DbContext(typeof(amusinghoSDbContext))]
    partial class amusinghoSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingArticle", b =>
                {
                    b.Property<string>("articleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(48)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DelTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(130)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("articleId");

                    b.ToTable("amusingArticles");
                });

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingArticleComment", b =>
                {
                    b.Property<string>("articleCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DelTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("amusingArticleId")
                        .HasColumnType("varchar(48)");

                    b.Property<string>("commentatorName")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("content")
                        .HasColumnType("LongText");

                    b.HasKey("articleCommentId");

                    b.HasIndex("amusingArticleId");

                    b.ToTable("amusingArticleComments");
                });

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingArticleDetails", b =>
                {
                    b.Property<string>("articleDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DelTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeleteId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Html")
                        .HasColumnType("LongText");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("amusingArticleId")
                        .HasColumnType("varchar(48)");

                    b.HasKey("articleDetailsId");

                    b.HasIndex("amusingArticleId")
                        .IsUnique();

                    b.ToTable("amusingArticleDetails");
                });

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingHosUser", b =>
                {
                    b.Property<string>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<string>("PassWord")
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.HasKey("userId");

                    b.ToTable("amusingHosUsers");
                });

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingArticleComment", b =>
                {
                    b.HasOne("amusinghoS.EntityData.Model.amusingArticle", "amusingArticle")
                        .WithMany("amusingArticleComments")
                        .HasForeignKey("amusingArticleId");
                });

            modelBuilder.Entity("amusinghoS.EntityData.Model.amusingArticleDetails", b =>
                {
                    b.HasOne("amusinghoS.EntityData.Model.amusingArticle", "amusingArticle")
                        .WithOne("amusingArticleDetails")
                        .HasForeignKey("amusinghoS.EntityData.Model.amusingArticleDetails", "amusingArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
