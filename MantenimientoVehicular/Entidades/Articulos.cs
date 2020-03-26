
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal  Cantidad { get; set; }
        public decimal Existencia { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Existencia = 0;
            Precio = 0;
            Fecha = DateTime.Now;
        }

    }
}
