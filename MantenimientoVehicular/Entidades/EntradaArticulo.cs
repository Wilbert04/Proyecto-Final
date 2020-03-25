using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class EntradaArticulo
    {
        [Key]
        public int EntradaVehiculoId { get; set; }
        public int ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Cantidad { get; set; }

        public EntradaArticulo()
        {
            EntradaVehiculoId = 0;
            ArticuloId = 0;
            NombreArticulo = string.Empty;
            Cantidad = 0;
        }
    }
}
