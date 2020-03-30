using System.ComponentModel.DataAnnotations;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class DetalleMantenimiento
    {
        [Key]
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public string ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public DetalleMantenimiento()
        {
            
        }

        public DetalleMantenimiento(int id, int mantenimientoId, string articuloId, string descripcion, decimal cantidad, decimal precio, decimal importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
