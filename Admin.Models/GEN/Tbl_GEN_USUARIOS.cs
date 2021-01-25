using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public partial class Tbl_GEN_USUARIOS 
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        
        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "El Username es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El Password es requerido")]
        [StringLength(255, ErrorMessage = "Minimo 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Canfirma password es requerido")]
        [StringLength(255, ErrorMessage = "Minimo 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm_Password { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Foto_Url { get; set; }
        public string Foto_Nombre { get; set; }


        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es requerido.")]
        public string Ap_Paterno { get; set; }

         //[Required(ErrorMessage = "El campo Apellido Materno es requerido.")]
        public string Ap_Materno { get; set; }
        public string Tel_Casa { get; set; }
        public string Tel_Cel { get; set; }
        public string Nextel_Radio { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        //public string Email { get; set; }

        [Required(ErrorMessage = "El campo Calle Paterno es requerido.")]
        public string Calle { get; set; }

        public string Num_Ext { get; set; }
        public string Num_Int { get; set; }
        public int? Id_Colonia { get; set; }

        [Required(ErrorMessage = "El campo Colonia Paterno es requerido.")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo Codigo postal Paterno es requerido.")]
        public string Cp { get; set; }

        public int? Id_Localidad { get; set; }

        [Required(ErrorMessage = "El campo Ciudad Paterno es requerido.")]
        public string Ciudad { get; set; }
        public int? Id_Municipio { get; set; }
        public string Municipio { get; set; }
        public int? Id_Estado { get; set; }
        public string Estado { get; set; }     
        public int? Id_Pais { get; set; }

        [Required(ErrorMessage = "El campo  Ciudad es requerido.")]
        public string Pais { get; set; }
        public int Id_Sucursal { get; set; }
        public int Id_Almacen { get; set; }
        public int? Dias_Para_Inactividad { get; set; }
        public DateTime? Ultimo_Acceso { get; set; }
        public string Aplica_Inactividad { get; set; }
        public DateTime? Fecha_Baja { get; set; }
        public bool Activo { get; set; }
        public int? Id_Serie { get; set; }

        [EmailAddress]
        public string email { get; set; }


    }
}
