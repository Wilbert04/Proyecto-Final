using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_MantenimientoVehicular.Entidades
{
   public class DetalleMantenimiento
    {
        [Key]
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public DetalleMantenimiento()
        {
            Id = 0;
            MantenimientoId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public DetalleMantenimiento(int id, int mantenimientoId, int articuloId, decimal cantidad, decimal precio, decimal importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
