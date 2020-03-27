using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class PedidosProveedores
    {
        [Key]
        public int PedidoId { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
       


        [ForeignKey("PedidoId")]
        public virtual List<DetallePedido> DPedidos { get; set; } = new List<DetallePedido>();

        public PedidosProveedores()
        {
            PedidoId = 0;
            Proveedor = string.Empty;
            Fecha = DateTime.Now;
            


        }
    }
}
