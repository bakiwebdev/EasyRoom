﻿// <auto-generated />
using System;
using EasyRoomServiceApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyRoomServiceApi.Migrations
{
    [DbContext(typeof(EasyRoomContext))]
    partial class EasyRoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyRoomServiceApi.Models.Friend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartnerID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PartnerID");

                    b.HasIndex("UserID");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Interest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Game")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromID")
                        .HasColumnType("int");

                    b.Property<int>("ToID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FromID");

                    b.HasIndex("ToID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FriendID")
                        .HasColumnType("int");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FriendID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Game")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Register", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostID")
                        .IsUnique();

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Friend", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.User", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyRoomServiceApi.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Interest", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.User", "User")
                        .WithOne("Interest")
                        .HasForeignKey("EasyRoomServiceApi.Models.Interest", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Message", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.User", "From")
                        .WithMany("Messages")
                        .HasForeignKey("FromID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EasyRoomServiceApi.Models.User", "To")
                        .WithMany()
                        .HasForeignKey("ToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Notification", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.Friend", "Friend")
                        .WithMany("Notifications")
                        .HasForeignKey("FriendID");

                    b.HasOne("EasyRoomServiceApi.Models.Post", "Post")
                        .WithMany("Notifications")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyRoomServiceApi.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Post", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Register", b =>
                {
                    b.HasOne("EasyRoomServiceApi.Models.Post", null)
                        .WithOne("Register")
                        .HasForeignKey("EasyRoomServiceApi.Models.Register", "PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyRoomServiceApi.Models.User", null)
                        .WithOne("Register")
                        .HasForeignKey("EasyRoomServiceApi.Models.Register", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Friend", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.Post", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("EasyRoomServiceApi.Models.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Interest");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("Posts");

                    b.Navigation("Register");
                });
#pragma warning restore 612, 618
        }
    }
}
