﻿// <auto-generated />
using ApiServiceTienda.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiServiceTienda.Migrations
{
    [DbContext(typeof(DBConecxion))]
    partial class DBConecxionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiServiceTienda.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<short>("Producto_Activo")
                        .HasColumnType("smallint");

                    b.Property<string>("Producto_Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Producto_Iva")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Producto_Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Producto_Precio_Venta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Producto_Precio_unitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ApiServiceTienda.Models.demo", b =>
                {
                    b.Property<int>("demoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("demoId"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("demoId");

                    b.ToTable("Demo");
                });
#pragma warning restore 612, 618
        }
    }
}
