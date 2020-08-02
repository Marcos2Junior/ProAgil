﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.API.Data;

namespace ProAgil.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200802035803_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProAgil.API.Model.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DataEvento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Local")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Lote")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("QntPessoas")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}