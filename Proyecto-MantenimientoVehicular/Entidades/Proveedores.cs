﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_MantenimientoVehicular.Entidades
{
    public class Proveedores
    {
        [Key]
        public int ProveedoresId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public DateTime Fecha { get; set; }

        public Proveedores()
        {
            ProveedoresId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Provincia = string.Empty;
            Ciudad = string.Empty;
            Calle = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}