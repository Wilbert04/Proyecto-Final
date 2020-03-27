using Microsoft.EntityFrameworkCore;
using Proyecto_MantenimientoVehicular.Entidades;

namespace Proyecto_MantenimientoVehicular.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<EntradaArticulos> entradaArticulos { get; set; }
        public DbSet<Articulos> articulos { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<PedidosProveedor> pedidosProveedor { get; set; }
        public DbSet<Mantenimiento> mantenimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Mantenimiento.db");
        }
    }
}
