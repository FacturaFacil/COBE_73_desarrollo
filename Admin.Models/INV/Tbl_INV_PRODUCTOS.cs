using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public  class Tbl_INV_PRODUCTOS
    {

        [Key]
        [Column(Order = 1)]
        public decimal Id_Dist { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Extendida { get; set; }
        public string Observaciones { get; set; }
        public string Clase { get; set; }
        public string Modelo { get; set; }
        public string Unidad { get; set; }
        public int? Id_Linea { get; set; }
        public int? Id_Sublinea { get; set; }
        public int? Id_Marca { get; set; }
        //public int? Id_ClaveIva { get; set; }
        public string Control_Fisico { get; set; }
        public string Codigo_Barras { get; set; }
        public decimal? Costo_Ultima_Compra { get; set; }
        public decimal? Costo_Promedio { get; set; }
        public string Id_Moneda { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Precio1 { get; set; }
        public decimal? Precio2 { get; set; }
        public decimal? Precio3 { get; set; }
        public decimal? Precio4 { get; set; }
        public decimal? Precio5 { get; set; }
        public decimal? Precio6 { get; set; }
        public decimal? Precio7 { get; set; }
        public decimal? Precio8 { get; set; }
        public bool Maneja_Peso_Por_Pieza { get; set; }
        public decimal? Peso_Pieza_En_Gramos { get; set; }
        public decimal? Peso_Pieza_En_Kilos { get; set; }
        public bool Maneja_Ieps { get; set; }
        public string Modo_Calculo_Ieps { get; set; }
        public int? Id_Cuenta_Mayor { get; set; }
        public int? Id_Nivel_2 { get; set; }
        public int? Id_Nivel_3 { get; set; }
        public int? Id_Nivel_4 { get; set; }
        public int? Id_Nivel_5 { get; set; }
        public bool Afecta_Almacen { get; set; }
        public bool Acepta_Descuento { get; set; }
        public bool Maneja_Series { get; set; }
        public bool Fraccion_En_Unidades { get; set; }
        public bool Captura_Peso { get; set; }
        public bool Permite_Compra { get; set; }
        public bool Permite_Venta { get; set; }
        public bool Maneja_Lista_Precio { get; set; }
        public bool Es_Producto_Terminado { get; set; }
        public DateTime? Fecha_Alta { get; set; }
        public bool Activo { get; set; }
        public string Id_Cve_Producto { get; set; }
        public string Id_Cve_Unidad { get; set; }
        public string Producto_Sustituto { get; set; }
        public bool Es_Paquete { get; set; }     
        public string Categoria_Ieps { get; set; }
        public bool Maneja_Iva_Tras { get; set; }       
        public bool Maneja_Iva_Ret { get; set; }
        public bool Maneja_Isr { get; set; }      
        public bool Maneja_Ieps_Ret { get; set; }      
        public bool Maneja_Iva_Desglosado { get; set; }
        public double? Cuenta_Predial { get; set; }
        public bool Maneja_Predial { get; set; }

        public string ruta_imagen { get; set; }


    }
}
