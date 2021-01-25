using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public partial class Tbl_GEN_ROLES
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public string Rol { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
       
    }
}
