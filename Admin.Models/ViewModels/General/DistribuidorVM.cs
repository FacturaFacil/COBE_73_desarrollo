using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.ViewModels
{
   public class DistribuidorVM
    {
        public Tbl_GEN_DISTRIBUIDORES Distribuidor { get; set; }
        public IEnumerable<SelectListItem> ListaUsuarios{ get; set; }
    }
}
