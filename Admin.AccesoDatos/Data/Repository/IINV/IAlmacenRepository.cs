using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IAlmacenRepository : IRepository<Tbl_INV_ALMACENES>
    {
        IEnumerable<SelectListItem> GetListaAlmacenes(decimal id_dist);


        void Update(Tbl_INV_ALMACENES almacen);


    }
}
