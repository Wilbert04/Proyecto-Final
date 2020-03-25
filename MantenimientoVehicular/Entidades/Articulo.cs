using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class Articulo
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }
        public decimal  Cantidad { get; set; }
        public decimal precio { get; set; }
        
        public Articulo()
        {
            ArticuloId = 0;
            Nombre = string.Empty;
            Cantidad = 0;
            precio = 0;
        }

    }
}
