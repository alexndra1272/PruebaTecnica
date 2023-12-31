﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20231207205553_initial mig")]
    partial class initialmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Backend.Data.Models.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdPersona")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("IdFactura");

                    b.HasIndex("IdPersona");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Backend.Data.Models.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidMaterno")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidPaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdPersona");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Backend.Data.Models.Factura", b =>
                {
                    b.HasOne("Backend.Data.Models.Persona", "Persona")
                        .WithMany("Factura")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Backend.Data.Models.Persona", b =>
                {
                    b.Navigation("Factura");
                });
#pragma warning restore 612, 618
        }
    }
}
