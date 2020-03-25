using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MantenimientoVehicular.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            Tipo = string.Empty;
            Nombre = string.Empty;
            Contraseña = string.Empty;
        }
    }
}
