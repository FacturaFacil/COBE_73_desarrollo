using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IRolRepository : IRepository<Tbl_GEN_ROLES>
    {
        IEnumerable<SelectListItem> GetListaRoles(decimal id_dist);


        void Update(Tbl_GEN_ROLES roles);
    }
}
