﻿// <auto-generated />
using System;
using Challenge_Backend_N5_WebAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge_Backend_N5_WebAPI.Infrastructure.Migrations
{
    [DbContext(typeof(DbContextChallengeN5))]
    [Migration("20230418015159_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Challenge_Backend_N5_WebAPI.Domain.Aggregates.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfPermission")
                        .HasColumnType("datetime")
                        .HasColumnName("FechaPermiso");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NombreEmpleado");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("ApellidoEmpleado");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("TipoPermiso");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Permisos", "dbo");
                });

            modelBuilder.Entity("Challenge_Backend_N5_WebAPI.Domain.Aggregates.PermissionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoPermisos", "dbo");
                });

            modelBuilder.Entity("Challenge_Backend_N5_WebAPI.Domain.Aggregates.Permission", b =>
                {
                    b.HasOne("Challenge_Backend_N5_WebAPI.Domain.Aggregates.PermissionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
