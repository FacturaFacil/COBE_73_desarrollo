using Admin.Models.GEN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public partial class Tbl_INV_ALMACENES
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 2)]

        [Required(ErrorMessage = "El campo clave es requerido.")]
        public int Id { get; set; }

          
        //[Key]
        //[Column(Order = 3)]
        [Required(ErrorMessage = "Es necesario seleccionar una sucursal.")]
        public int Id_Sucursal { get; set; }


        [ForeignKey("Id_Sucursal , Id_Dist")]
        public virtual Tbl_GEN_SUCURSALES Sucursal { get; set; }



        [Required(ErrorMessage = "El campo Descripciónn es requerido.")]
        public string Descripcion { get; set; }
        public bool Predeterminado { get; set; }
        public bool Activo { get; set; }

       
    }
}
