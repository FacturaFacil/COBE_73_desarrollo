using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IModuloRepository : IRepository<Tbl_GEN_MODULOS>
    {
        IEnumerable<SelectListItem> GetListaModulos();


        void Update(Tbl_GEN_MODULOS modulo);
    }
}
