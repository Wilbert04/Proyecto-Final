using System.ComponentModel.DataAnnotations;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class DetallePedidos
    {
        
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProveedorId { get; set; }
        public string Articulo { get; set; }
        public int Unidad { get; set; }


        
        

        public DetallePedidos()
        {

        }

        public DetallePedidos(int id, int pedidoId, int proveedor, string articulo, int unidad)
        {
            Id = id;
            PedidoId = pedidoId;
            ProveedorId = proveedor;
            Articulo = articulo;
            Unidad = unidad;
        }
    }
}
