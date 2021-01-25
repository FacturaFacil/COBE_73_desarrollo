using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface IClaseGastoRepository : IRepository<Tbl_INV_CLASESGASTOS>
    {
        IEnumerable<SelectListItem> GetListaClaseGastos(decimal id_dist);


        void Update(Tbl_INV_CLASESGASTOS obj);

        void UpdatePredeterminado(decimal id_dist, int id_clase_gasto);
    }
}
