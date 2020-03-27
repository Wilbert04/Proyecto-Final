using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class PedidosProveedor
    {
        [Key]
        public int PedidoId { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }



        [ForeignKey("PedidoId")]
        public virtual List<DetallePedidos> DPedidos { get; set; } = new List<DetallePedidos>();

         public PedidosProveedor()
        {
            PedidoId = 0;
            Proveedor = string.Empty;
            Fecha = DateTime.Now;



        }
    }
}
