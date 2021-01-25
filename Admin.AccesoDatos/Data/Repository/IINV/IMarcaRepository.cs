using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IINV
{
  public  interface IMarcaRepository : IRepository<Tbl_INV_MARCAS>
    {
        IEnumerable<SelectListItem> GetListaMarcas(decimal id_dist);


        void Update(Tbl_INV_MARCAS marca);
    }
}
