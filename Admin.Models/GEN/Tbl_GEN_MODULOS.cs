using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Tbl_GEN_MODULOS
    {
        

        [Key]
        [MaxLength(6, ErrorMessage = "El maximo de caracteres permitido es de 6.")]
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public bool Activo { get; set; }

      
    }
}
