﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SecretSharing.Persistence;

namespace SecretSharing.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DocumentUserProfile", b =>
                {
                    b.Property<Guid>("DocumentsGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersGuid")
                        .HasColumnType("uuid");

                    b.HasKey("DocumentsGuid", "UsersGuid");

                    b.HasIndex("UsersGuid");

                    b.ToTable("UsersDocument");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SecretSharing.Application.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SecretSharing.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatorGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Guid");

                    b.HasIndex("CreatorGuid");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("SecretSharing.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.HasKey("Guid");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("DocumentUserProfile", b =>
                {
                    b.HasOne("SecretSharing.Domain.Entities.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentsGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSharing.Domain.Entities.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("UsersGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SecretSharing.Application.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SecretSharing.Application.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSharing.Application.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SecretSharing.Application.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecretSharing.Domain.Entities.Document", b =>
                {
                    b.HasOne("SecretSharing.Domain.Entities.UserProfile", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorGuid");

                    b.OwnsOne("SecretSharing.Domain.ValueObjects.DocumentName", "Name", b1 =>
                        {
                            b1.Property<Guid>("DocumentGuid")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("Name");

                            b1.HasKey("DocumentGuid");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("DocumentGuid");
                        });

                    b.OwnsOne("SecretSharing.Domain.ValueObjects.S3Info", "S3Info", b1 =>
                        {
                            b1.Property<Guid>("DocumentGuid")
                                .HasColumnType("uuid");

                            b1.Property<string>("BucketName")
                                .HasColumnType("text")
                                .HasColumnName("BucketName");

                            b1.Property<string>("FileName")
                                .HasColumnType("text")
                                .HasColumnName("FileName");

                            b1.Property<string>("FolderName")
                                .HasColumnType("text")
                                .HasColumnName("FolderName");

                            b1.Property<string>("LocalPath")
                                .HasColumnType("text")
                                .HasColumnName("LocalPath");

                            b1.HasKey("DocumentGuid");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("DocumentGuid");
                        });

                    b.Navigation("Creator");

                    b.Navigation("Name");

                    b.Navigation("S3Info");
                });

            modelBuilder.Entity("SecretSharing.Domain.Entities.UserProfile", b =>
                {
                    b.OwnsOne("SecretSharing.Domain.ValueObjects.Name", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("UserProfileGuid")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("FirstName");

                            b1.HasKey("UserProfileGuid");

                            b1.ToTable("UserProfile");

                            b1.WithOwner()
                                .HasForeignKey("UserProfileGuid");
                        });

                    b.OwnsOne("SecretSharing.Domain.ValueObjects.Name", "LastName", b1 =>
                        {
                            b1.Property<Guid>("UserProfileGuid")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("LastName");

                            b1.HasKey("UserProfileGuid");

                            b1.ToTable("UserProfile");

                            b1.WithOwner()
                                .HasForeignKey("UserProfileGuid");
                        });

                    b.Navigation("FirstName");

                    b.Navigation("LastName");
                });
#pragma warning restore 612, 618
        }
    }
}
