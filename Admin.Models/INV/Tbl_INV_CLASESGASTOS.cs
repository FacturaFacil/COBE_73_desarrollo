using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public  class Tbl_INV_CLASESGASTOS
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "El campo clave es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        public string Descripcion { get; set; }
        public bool Predefinido { get; set; }
        public bool Activo { get; set; }

       
    }
}
