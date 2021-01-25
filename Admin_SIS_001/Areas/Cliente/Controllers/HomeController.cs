using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admin_SIS_001.Models;
using Admin.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Admin.Models;
using Admin_SIS_001.Filter;

namespace Admin_SIS_001.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
     
        private readonly ILogger<HomeController> _logger;
        private readonly IContenedorTrabajo _contenedorTrabajo;

        //private readonly int id_dist = 1;
        public HomeController(ILogger<HomeController> logger, IContenedorTrabajo contenedorTrabajo)
        {
            _logger = logger;
            _contenedorTrabajo = contenedorTrabajo;
           
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Lagout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }

        [HttpGet]
        public JsonResult CerrarSessiones()
        {
            HttpContext.Session.Clear();
            return Json(new { success = true, message = "" });
        }
        public ActionResult GetMenuList()
        {
            try
            {
                var result = _contenedorTrabajo.Menu.GetAll().ToList();
                return View("Menu", result);
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                return Content("Error");
            }
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
