﻿// <auto-generated />
using System;
using BlazorIdentityServerTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorIdentityServerTest.Migrations.Journal
{
    [DbContext(typeof(JournalContext))]
    [Migration("20220822124051_Changed datatype")]
    partial class Changeddatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("BlazorIdentityServerTest.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Filename")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("filename");

                    b.Property<int?>("JournalId")
                        .HasColumnType("int(11)")
                        .HasColumnName("journal_id");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.Property<string>("Uri")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("uri");

                    b.HasKey("Id");

                    b.ToTable("attachments", (string)null);
                });

            modelBuilder.Entity("BlazorIdentityServerTest.Models.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("AssignedEmployee")
                        .HasColumnType("int(11)")
                        .HasColumnName("assigned_employee");

                    b.Property<int>("AssignedPatient")
                        .HasColumnType("int(11)")
                        .HasColumnName("assigned_patient");

                    b.Property<DateTime>("Date")
                        .HasMaxLength(255)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("int(11)")
                        .HasColumnName("hospital_id");

                    b.Property<string>("Text")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.ToTable("journals", (string)null);
                });

            modelBuilder.Entity("BlazorIdentityServerTest.Models.JournalApprove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("EditorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("editor_id");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int(11)")
                        .HasColumnName("owner_id");

                    b.Property<int?>("PageId")
                        .HasColumnType("int(11)")
                        .HasColumnName("page_id");

                    b.HasKey("Id");

                    b.ToTable("journal_approve", (string)null);
                });

            modelBuilder.Entity("BlazorIdentityServerTest.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Date")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("date");

                    b.Property<string>("Text")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.ToTable("pages", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
