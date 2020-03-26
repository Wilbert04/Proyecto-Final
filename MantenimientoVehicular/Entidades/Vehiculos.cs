using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public string TipoVehiculo { get; set; }
        public string Descripcion { get; set; }
        public int Año { get; set; }
        public DateTime Fecha { get; set; }
        public Vehiculos()
        {
            VehiculoId = 0;
            ClienteId = 0;
            TipoVehiculo = string.Empty;
            Descripcion = string.Empty;
            Año = 0;
            Fecha = DateTime.Now;
        }
    }
}
