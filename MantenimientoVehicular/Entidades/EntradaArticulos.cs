using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class EntradaArticulos
    {
        [Key]
        public int EntradaArticuloId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public EntradaArticulos()
        {
            EntradaArticuloId = 0;
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Fecha = DateTime.Now;
        }
    }
}
