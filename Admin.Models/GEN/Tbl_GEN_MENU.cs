using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public  class Tbl_GEN_MENU
    {
        [Key]
        public decimal Id { get; set; }
        public string Descripcion { get; set; }
        public decimal? Id_Padre { get; set; }
        public int? Posicion { get; set; }
        public string Icono { get; set; }
        public bool? Habilitado { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public bool? Menu { get; set; }
        public string Estatus { get; set; }
    }
}
