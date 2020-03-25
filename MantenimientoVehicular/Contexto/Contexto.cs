using MantenimientoVehicular.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MantenimientoVehicular.Contexto
{
    public class Contexto :DbContext
    {

        public DbSet<Articulo> articulo { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<EntradaArticulo> entraArticulo { get; set; }
        public DbSet<Mantenimiento> mantenimiento { get; set; }
        public DbSet<PedidoProveedores> PedidoProveedores { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Vehiculo> vehiculo  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" DataSource = MantenimientoDB.db");
        }
    }
}
