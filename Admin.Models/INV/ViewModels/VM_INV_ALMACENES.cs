using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.INV.ViewModels
{
   public class VM_INV_ALMACENES
    {
        public Tbl_INV_ALMACENES Almacen { get; set; }

        public IEnumerable<SelectListItem> ListaSucursales { get; set; }
    }
}
