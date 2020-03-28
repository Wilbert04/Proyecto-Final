using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public string ClienteId { get; set; }
        public string TipoVehiculo { get; set; }
        public string Descripcion { get; set; }
        public int Año { get; set; }
        public DateTime Fecha { get; set; }

        
        public Vehiculos()
        {
            VehiculoId = 0;
            ClienteId = string.Empty;
            TipoVehiculo = string.Empty;
            Descripcion = string.Empty;
            Año = 0;
            Fecha = DateTime.Now;
        }

    }
}
