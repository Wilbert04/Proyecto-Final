using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class PedidoProveedores
    {
        [Key]
        public int PedidoId { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("PedidoId")]
        public virtual List<DetallePedidoProveedor> DPedidos { get; set; }

        public PedidoProveedores(int pedidoId, string proveedor, DateTime fecha, decimal subTotal, decimal itebis, decimal total, List<DetallePedidoProveedor> dPedidos)
        {
            PedidoId = pedidoId;
            Proveedor = proveedor;
            Fecha = fecha;
            SubTotal = subTotal;
            Itebis = itebis;
            Total = total;
            DPedidos = dPedidos;
        }
    }
}
