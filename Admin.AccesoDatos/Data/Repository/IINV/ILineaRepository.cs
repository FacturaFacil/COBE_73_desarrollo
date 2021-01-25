using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface ILineaRepository : IRepository<Tbl_INV_LINEAS>
    {
        IEnumerable<SelectListItem> GetListaLineas(decimal id_dist);


        void Update(Tbl_INV_LINEAS linea);
    }
}
