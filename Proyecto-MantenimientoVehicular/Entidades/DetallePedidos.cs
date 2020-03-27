using System.ComponentModel.DataAnnotations;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class DetallePedidos
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public DetallePedidos()
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
