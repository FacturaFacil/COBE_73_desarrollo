using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface IProductoRepository : IRepository<Tbl_INV_PRODUCTOS>
    {
        IEnumerable<SelectListItem> GetListaProductos(decimal id_dist);


        void Update(Tbl_INV_PRODUCTOS producto);
    }
}
