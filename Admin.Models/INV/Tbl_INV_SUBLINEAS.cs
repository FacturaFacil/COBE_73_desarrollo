using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public  class Tbl_INV_SUBLINEAS
    {


        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }


        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "La linea es requerida.")]       
        public int? Id_Linea { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "El campo clave es requerido.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo descripción es requerido.")]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }


        [ForeignKey("Id_Linea , Id_Dist")]
        public virtual Tbl_INV_LINEAS Lineas { get; set; }


    }
}
