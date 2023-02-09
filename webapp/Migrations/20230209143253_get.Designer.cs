﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapp.Database;

#nullable disable

namespace webapp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230209143253_get")]
    partial class get
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapp.Features.Assignments.Models.AssignmentModel", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Grade")
                        .HasColumnType("real");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("webapp.Features.Subject.SubjectModels.SubjectModel", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<double>>("Grades")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfessorMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("webapp.Features.Test.TestModels.TestModel", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Grade")
                        .HasColumnType("real");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
