using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.IGEN
{
  public  interface IModuloOpcionesRepository : IRepository<Tbl_GEN_MODULOS_OPCIONES>
    {
        IEnumerable<SelectListItem> GetListaModulosOpciones();


        void Update(Tbl_GEN_MODULOS_OPCIONES modulo);
    }
}
