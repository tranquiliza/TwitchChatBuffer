﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Core.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tranquiliza.BufferedChat.Core.Domain.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Channel");

                    b.Property<string>("DisplayName");

                    b.Property<string>("EmoteReplacedMessage");

                    b.Property<string>("Message");

                    b.Property<DateTime>("ReceivedAt");

                    b.Property<string>("UserColorHex");

                    b.Property<string>("UserId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Tranquiliza.BufferedChat.Core.Domain.Integration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IntegrationUrl");

                    b.Property<Guid?>("UserId");

                    b.Property<bool>("Visible");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Integration");
                });

            modelBuilder.Entity("Tranquiliza.BufferedChat.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TwitchUsername");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tranquiliza.BufferedChat.Core.Domain.Integration", b =>
                {
                    b.HasOne("Tranquiliza.BufferedChat.Core.Domain.User")
                        .WithMany("Integrations")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
