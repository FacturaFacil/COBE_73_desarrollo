using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.INV.ViewModels
{
   public class VM_INV_PRODUCTOS
    {
        public Tbl_INV_PRODUCTOS Producto { get; set; }

        public IEnumerable<SelectListItem> ListaLineas { get; set; }

        public IEnumerable<SelectListItem> ListaSubLineas { get; set; }

        public IEnumerable<SelectListItem> ListaMarcas{ get; set; }

        public List<Tbl_INV_PRODUCTOS_IMPUESTOS> ListaImpuestos { get; set; }
    }
}
