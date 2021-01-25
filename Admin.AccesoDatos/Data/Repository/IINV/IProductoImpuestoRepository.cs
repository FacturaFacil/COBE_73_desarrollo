using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface IProductoImpuestoRepository : IRepository<Tbl_INV_PRODUCTOS_IMPUESTOS>
    {
        IEnumerable<SelectListItem> GetListaProductoImpuestos(decimal id_dist);


        void Update(Tbl_INV_PRODUCTOS_IMPUESTOS producto_impuesto);
    }
}
