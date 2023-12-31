﻿// <auto-generated />
using System;
using MagicCards.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace MagicCards.Migrations
{
    [DbContext(typeof(MagicDbContext))]
    [Migration("20230906215214_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicCards.Models.Carta", b =>
                {
                    b.Property<int>("CartaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartaId"));

                    b.Property<int>("ColecaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IlustradorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CartaId");

                    b.HasIndex("ColecaoId");

                    b.HasIndex("IlustradorId");

                    b.ToTable("Carta", (string)null);
                });

            modelBuilder.Entity("MagicCards.Models.Colecao", b =>
                {
                    b.Property<int>("ColecaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColecaoId"));

                    b.Property<DateTime>("Ano")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ColecaoId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("MagicCards.Models.Ilustrador", b =>
                {
                    b.Property<int>("IlustradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlustradorId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IlustradorId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("MagicCards.Models.Carta", b =>
                {
                    b.HasOne("MagicCards.Models.Colecao", "Colecao")
                        .WithMany("Cartas")
                        .HasForeignKey("ColecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicCards.Models.Ilustrador", "Ilustrador")
                        .WithMany("Cartas")
                        .HasForeignKey("IlustradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");

                    b.Navigation("Ilustrador");
                });

            modelBuilder.Entity("MagicCards.Models.Colecao", b =>
                {
                    b.Navigation("Cartas");
                });

            modelBuilder.Entity("MagicCards.Models.Ilustrador", b =>
                {
                    b.Navigation("Cartas");
                });
#pragma warning restore 612, 618
        }
    }
}
