using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public partial class Tbl_GEN_MODULOS_OPCIONES
    {


        [Key]
        [Column(Order = 1)]
        [MaxLength(6, ErrorMessage = "El maximo de caracteres permitido es de 6.")]
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public string Id { get; set; }

        [Key]
        [Column(Order = 2)]

        [Required(ErrorMessage = "El Modulo es obligatorio.")]
        public string Id_Modulo { get; set; }

        [ForeignKey("Id_Modulo")]
        public virtual Tbl_GEN_MODULOS Modulos { get; set; }


        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }

      
    }
}
