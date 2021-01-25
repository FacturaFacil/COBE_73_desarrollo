using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Tbl_GEN_DISTRIBUIDORES
    {
        [Key]
        public decimal Id { get; set; }
        public string Razon_Social { get; set; }
        public string Rfc { get; set; }
        public string Regimen_Fiscal { get; set; }
        public string Nombre_Comercial { get; set; }
        public decimal? Id_Padre { get; set; }
        public string Es_Distribuidor { get; set; }
        public string Es_Cliente { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime? Fecha_Alta { get; set; }
        public decimal? Patrocinador { get; set; }
        public string Activo { get; set; }
        public int Numero_Usuarios { get; set; }
        public string Calle { get; set; }
        public string Num_Ext { get; set; }
        public string Num_Int { get; set; }
        public string Cp { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Enviado_Por { get; set; }
        public string Asunto_Email { get; set; }
        public string Logo_Url { get; set; }
        public double? Version_Facturacion { get; set; }

       
    }
}
