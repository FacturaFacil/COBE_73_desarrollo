using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.INV.ViewModels
{
   public class VM_INV_SUBLINEAS
    {
        public Tbl_INV_SUBLINEAS SubLinea { get; set; }

        public IEnumerable<SelectListItem> ListaLineas { get; set; }
    }
}
