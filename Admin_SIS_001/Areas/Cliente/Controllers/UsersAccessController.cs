using Admin.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_SIS_001.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class UsersAccessController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsersAccessController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;

        }
        public IActionResult NotAuthorized()
        {           
            return View();
        }
    }
}
