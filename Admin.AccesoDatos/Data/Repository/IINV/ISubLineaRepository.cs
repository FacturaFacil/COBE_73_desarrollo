using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface ISubLineaRepository : IRepository<Tbl_INV_SUBLINEAS>
    {
        IEnumerable<SelectListItem> GetListaSubLineas(decimal id_dist, int id_linea);


        void Update(Tbl_INV_SUBLINEAS sublinea);
    }
}
