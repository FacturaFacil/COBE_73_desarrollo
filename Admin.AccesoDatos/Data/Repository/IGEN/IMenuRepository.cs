using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IMenuRepository : IRepository<Tbl_GEN_MENU>
    {
        IEnumerable<SelectListItem> GetListaMenu();


        void Update(Tbl_GEN_MENU marca);
    }
}
