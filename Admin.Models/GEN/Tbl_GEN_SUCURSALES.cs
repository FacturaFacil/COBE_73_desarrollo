using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Admin.Models.GEN
{
  public  class Tbl_GEN_SUCURSALES
    {
        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo calle es obligatorio.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo No. Exteriror es obligatorio.")]
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public int? Id_Pais { get; set; }

        [Required(ErrorMessage = "El campo pais es obligatorio.")]
        public string Pais { get; set; }
        public int? Id_Estado { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio.")]
        public string Estado { get; set; }
        public int? Id_Municipio { get; set; }

        [Required(ErrorMessage = "El campo municipio es obligatorio.")]
        public string Municipio_Deleg { get; set; }
        public int? Id_Poblacion { get; set; }

        [Required(ErrorMessage = "El campo ciudad es obligatorio.")]
        public string Ciudad { get; set; }
        public int? Id_Colonia { get; set; }

        [Required(ErrorMessage = "El campo colonia es obligatorio.")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo Codigo Postal es obligatorio.")]
        public string Cp { get; set; }
        public string Referencia { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public int? Id_Folio { get; set; }
        public bool Matriz_Sucursal { get; set; }
        public string Responsable { get; set; }
        public string Desc_Corta { get; set; }
        public string Telefonos { get; set; }
        public string Fax { get; set; }
        public string Calle_Y_Numero { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }



        //public virtual List<Tbl_INV_ALMACENES> Almacenes { get; set; }
    }
}
