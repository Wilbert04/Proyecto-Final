using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public DetallePedido()
        {
            Id = 0;
            PedidoId = 0;
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }
    }
}
