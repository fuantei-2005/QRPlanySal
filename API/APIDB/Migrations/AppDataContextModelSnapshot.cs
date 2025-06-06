﻿// <auto-generated />
using APIDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIDB.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("APIDB.Model.Biblioteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Biblioteka");
                });

            modelBuilder.Entity("APIDB.Model.Ksiazka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ksiazka");
                });

            modelBuilder.Entity("BibliotekaKsiazka", b =>
                {
                    b.Property<int>("BibliotekaId")
                        .HasColumnType("int");

                    b.Property<int>("ListaKsiazekId")
                        .HasColumnType("int");

                    b.HasKey("BibliotekaId", "ListaKsiazekId");

                    b.HasIndex("ListaKsiazekId");

                    b.ToTable("BibliotekaKsiazka");
                });

            modelBuilder.Entity("BibliotekaKsiazka", b =>
                {
                    b.HasOne("APIDB.Model.Biblioteka", null)
                        .WithMany()
                        .HasForeignKey("BibliotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIDB.Model.Ksiazka", null)
                        .WithMany()
                        .HasForeignKey("ListaKsiazekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
