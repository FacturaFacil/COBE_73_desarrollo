using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models.GEN.ViewModels
{
    public class VM_GEN_MODULOS_OPCIONES
    {
        public Tbl_GEN_MODULOS_OPCIONES ModulosOpciones { get; set; }
        public IEnumerable<SelectListItem> ListaModulos { get; set; }
    }
}
