using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public partial class Tbl_GEN_ROLES_PERMISOS
    {
        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Id_Rol { get; set; }
        [Key]
        [Column(Order = 3)]
        public string Id_Modulo { get; set; }
        [Key]
        [Column(Order = 4)]
        public string Id_Opciones { get; set; }
        public bool Accesar { get; set; }
        public bool Nuevo { get; set; }
        public bool Modificar { get; set; }
        public bool Eliminar { get; set; }
        public bool Cancelar { get; set; }
        public bool Imprimir { get; set; }
      
    }
}
