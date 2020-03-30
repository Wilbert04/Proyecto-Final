using System.ComponentModel.DataAnnotations;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class DetallePedidos
    {
        private int v1;
        private int v2;
        private decimal v3;

        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }


        
        public DetallePedidos(int id, int pedidoId, int articuloId, string descripcion, decimal cantidad)
        {
            Id = id;
            PedidoId = pedidoId;
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Cantidad = cantidad;
        }

        public DetallePedidos()
        {

        }

        public DetallePedidos(int pedidoId, int v1, int v2, decimal v3)
        {
            PedidoId = pedidoId;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}
