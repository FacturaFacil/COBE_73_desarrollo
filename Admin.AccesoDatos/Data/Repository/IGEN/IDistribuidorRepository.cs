using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IDistribuidorRepository : IRepository<Tbl_GEN_DISTRIBUIDORES>
    {
        IEnumerable<SelectListItem> GetListaDistribuidores();


        void Update(Tbl_GEN_DISTRIBUIDORES distribuidor);
    }
}
