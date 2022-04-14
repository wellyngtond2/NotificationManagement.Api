﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationManagement.Infra.Data;

namespace NotificationManagement.Infra.Migrations
{
    [DbContext(typeof(NotificationDbContext))]
    [Migration("20220405115527_add_person_seed")]
    partial class add_person_seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotificationManagement.Domain.Domain.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.HasIndex("PersonId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("NotificationManagement.Domain.Domain.Models.NotificationTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplates");
                });

            modelBuilder.Entity("NotificationManagement.Domain.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 4, 5, 8, 55, 27, 531, DateTimeKind.Local).AddTicks(147),
                            Email = "joao@devscope.net",
                            Name = "João",
                            PhoneNumber = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7609),
                            Email = "pedro@devscope.net",
                            Name = "Pedro",
                            PhoneNumber = "23456789"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7666),
                            Email = "marcos@devscope.net",
                            Name = "Marcos",
                            PhoneNumber = "34567890"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7672),
                            Email = "carlos@devscope.net",
                            Name = "Carlos",
                            PhoneNumber = "45678901"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2022, 4, 5, 8, 55, 27, 533, DateTimeKind.Local).AddTicks(7676),
                            Email = "emanuel@devscope.net",
                            Name = "Emanuel",
                            PhoneNumber = "56789012"
                        });
                });

            modelBuilder.Entity("NotificationManagement.Domain.Domain.Models.Notification", b =>
                {
                    b.HasOne("NotificationManagement.Domain.Domain.Models.NotificationTemplate", "NotificationTemplate")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotificationManagement.Domain.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationTemplate");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}