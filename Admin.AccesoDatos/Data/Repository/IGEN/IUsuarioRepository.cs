using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IUsuarioRepository : IRepository<Tbl_GEN_USUARIOS>
    {
        IEnumerable<SelectListItem> GetListaUsuarios(decimal id_dist);


        void Update(Tbl_GEN_USUARIOS usuario);
    }
}
