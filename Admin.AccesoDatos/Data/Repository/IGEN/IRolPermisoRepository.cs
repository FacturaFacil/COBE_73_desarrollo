using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IRolPermisoRepository : IRepository<Tbl_GEN_ROLES_PERMISOS>
    {
        IEnumerable<SelectListItem> GetListaRolesPermisos(decimal id_dist);


        void Update(Tbl_GEN_ROLES_PERMISOS rolesPermisos);
    }
}
