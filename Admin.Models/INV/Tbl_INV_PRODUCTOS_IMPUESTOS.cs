using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public  class Tbl_INV_PRODUCTOS_IMPUESTOS
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Id { get; set; }
        public string Id_Categoria_Ieps { get; set; }
        public string Id_Producto { get; set; }
        public int Id_Impuesto { get; set; }
        public string Descripcion_Impuesto { get; set; }
        public string Tipo_Factor { get; set; }
        public string Tasa_O_Cuota { get; set; }
        public string Desglosado { get; set; }
        public string Cantidad_Cuota_Ieps { get; set; }
        public string Unidad_Cuota_Ieps { get; set; }
        public string Tipo_Impuesto { get; set; }
    }
}
