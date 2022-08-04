﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using homeWork9.Models;

#nullable disable

namespace homeWork9.Migrations
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("email")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("homeWork9.Models.ContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Contacts", "email");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "a59-info@yandex.ru"
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "silenceafter@yandex.ru"
                        },
                        new
                        {
                            Id = 3,
                            EmailAddress = "axasthur89@mail.ru"
                        },
                        new
                        {
                            Id = 4,
                            EmailAddress = "a8959@mail.ru"
                        },
                        new
                        {
                            Id = 5,
                            EmailAddress = "a25031992@gmail.com"
                        });
                });

            modelBuilder.Entity("homeWork9.Models.MessageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FromId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsHtml")
                        .HasColumnType("boolean");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ToId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Messages", "email");
                });
#pragma warning restore 612, 618
        }
    }
}
