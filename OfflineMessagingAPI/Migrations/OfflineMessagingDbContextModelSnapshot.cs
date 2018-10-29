﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfflineMessagingAPI.DataContext;

namespace OfflineMessagingAPI.Migrations
{
    [DbContext(typeof(OfflineMessagingDbContext))]
    partial class OfflineMessagingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfflineMessagingAPI.Models.ActivityLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityContent");

                    b.Property<DateTime>("ActivityTime");

                    b.Property<int?>("customUserID");

                    b.HasKey("Id");

                    b.HasIndex("customUserID");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.BlockUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BlockedDate");

                    b.Property<int?>("BlockedUserID");

                    b.Property<int?>("BlockerUserID");

                    b.HasKey("Id");

                    b.HasIndex("BlockedUserID");

                    b.HasIndex("BlockerUserID");

                    b.ToTable("BlockUser");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.Chats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReceiverDeleteTime");

                    b.Property<int>("ReceiverId");

                    b.Property<DateTime>("SenderDeleteTime");

                    b.Property<int>("SenderId");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.CustomUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsOnline");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UploadDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("CustomUser");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.Messages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChatId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsMessageReached");

                    b.Property<bool>("IsMessageSeen");

                    b.Property<string>("MessageContent")
                        .IsRequired();

                    b.Property<int>("ReceiverId");

                    b.Property<int>("SenderId");

                    b.Property<DateTime>("TransmissionTime");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("ID");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.PublicLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogContent");

                    b.Property<DateTime>("LogTime");

                    b.HasKey("Id");

                    b.ToTable("PublicLogs");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.ActivityLogs", b =>
                {
                    b.HasOne("OfflineMessagingAPI.Models.CustomUser", "customUser")
                        .WithMany()
                        .HasForeignKey("customUserID");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.BlockUser", b =>
                {
                    b.HasOne("OfflineMessagingAPI.Models.CustomUser", "BlockedUser")
                        .WithMany()
                        .HasForeignKey("BlockedUserID");

                    b.HasOne("OfflineMessagingAPI.Models.CustomUser", "BlockerUser")
                        .WithMany()
                        .HasForeignKey("BlockerUserID");
                });

            modelBuilder.Entity("OfflineMessagingAPI.Models.Messages", b =>
                {
                    b.HasOne("OfflineMessagingAPI.Models.Chats", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");
                });
#pragma warning restore 612, 618
        }
    }
}
