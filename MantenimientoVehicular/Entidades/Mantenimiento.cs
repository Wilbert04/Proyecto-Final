using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantemientoId { get; set; }
        public DateTime ProximoMantemiento { get; set; }
        public string Vehiculo { get; set; }
        public string Cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("MantenimientoId")]
        public virtual List<DetalleMantenimiento> Dmantenimiento { get; set; }

        public Mantenimiento(int mantemientoId, DateTime proximoMantemiento, string vehiculo, string cliente, decimal subTotal, decimal itebis, decimal total, List<DetalleMantenimiento> dmantenimiento)
        {
            MantemientoId = mantemientoId;
            ProximoMantemiento = proximoMantemiento;
            Vehiculo = vehiculo;
            Cliente = cliente;
            SubTotal = subTotal;
            Itebis = itebis;
            Total = total;
            Dmantenimiento = dmantenimiento;
        }
    }
}
