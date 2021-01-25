using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.GEN.ViewModels
{
    public class VM_GEN_ROLES_PERMISOS
    {
      

        public Tbl_GEN_ROLES_PERMISOS rolesPermisos { get; set; }

        public IEnumerable<SelectListItem> ListaModulos { get; set; }

        public IEnumerable<SelectListItem> ListaRoles { get; set; }
    }
}
