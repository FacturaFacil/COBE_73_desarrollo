using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface ISucursalRepository : IRepository<Tbl_GEN_SUCURSALES>
    {
        IEnumerable<SelectListItem> GetListaSucursales(decimal id_dist);


        void Update(Tbl_GEN_SUCURSALES sucursal);
    }
}
