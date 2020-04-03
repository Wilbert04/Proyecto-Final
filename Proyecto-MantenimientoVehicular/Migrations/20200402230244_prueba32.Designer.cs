﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_MantenimientoVehicular.DAL;

namespace Proyecto_MantenimientoVehicular.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200402230244_prueba32")]
    partial class prueba32
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Articulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticuloId");

                    b.ToTable("articulos");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.DetalleMantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Importe")
                        .HasColumnType("TEXT");

                    b.Property<int>("MantenimientoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MantenimientoId");

                    b.ToTable("DetalleMantenimiento");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.DetallePedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Articulo")
                        .HasColumnType("TEXT");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Unidad")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.EntradaArticulos", b =>
                {
                    b.Property<int>("EntradaArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("EntradaArticuloId");

                    b.ToTable("entradaArticulos");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("MantenimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Itebis")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProximoMantemiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Servicios")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MantenimientoId");

                    b.ToTable("mantenimientos");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.PedidosProveedor", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nota")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProveedoresId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PedidoId");

                    b.ToTable("pedidosProveedor");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Proveedores", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("RNC")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ProveedorId");

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contraseña")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Vehiculos", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Año")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoVehiculo")
                        .HasColumnType("TEXT");

                    b.HasKey("VehiculoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("vehiculos");
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.DetalleMantenimiento", b =>
                {
                    b.HasOne("Proyecto_MantenimientoVehicular.Entidades.Mantenimiento", null)
                        .WithMany("DMantenimiento")
                        .HasForeignKey("MantenimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.DetallePedidos", b =>
                {
                    b.HasOne("Proyecto_MantenimientoVehicular.Entidades.PedidosProveedor", null)
                        .WithMany("DPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_MantenimientoVehicular.Entidades.Vehiculos", b =>
                {
                    b.HasOne("Proyecto_MantenimientoVehicular.Entidades.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}