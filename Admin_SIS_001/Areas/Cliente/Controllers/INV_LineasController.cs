using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data;
using Admin.AccesoDatos.Data.Repository;
using Admin.Models;
using Admin_SIS_001.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_SIS_001.Areas.Admin.Controllers
{
    [Area("Cliente")]
    [TypeFilter(typeof(MiExcepciones))]
    public class INV_LineasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;

        public INV_LineasController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _httpContextAccessor = httpContextAccessor;

        }
        [SessionCheck]
        public IActionResult Index()
        {
            return View();
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Create()
        {
           var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
           var objDoc = _contenedorTrabajo.Linea.GetAll(a => a.Id_Dist == id_dist).LastOrDefault();
           int folio = 0;         
            if (objDoc != null)folio = objDoc.Id + 1; else folio = 1;
            ViewBag.folio = folio;
            return View();
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_INV_LINEAS linea)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {

                linea.Id_Dist = id_dist;              
                _contenedorTrabajo.Linea.Add(linea);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(linea);
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            Tbl_INV_LINEAS linea = new Tbl_INV_LINEAS();
            linea = _contenedorTrabajo.Linea.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (linea == null)
            {
                ViewBag.ErrorTitulo = "No existe linea" ;
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
            }           
            return View(linea);
        }


        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tbl_INV_LINEAS linea)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {
                linea.Id_Dist = id_dist;               
                _contenedorTrabajo.Linea.Update(linea);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(linea);
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var marcaDedeBD = _contenedorTrabajo.Linea.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (marcaDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando marca" });
            }

            _contenedorTrabajo.Linea.Remove(marcaDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }



        #region LLAMADAS A LA API

        [SessionCheck]
        [HttpGet]
        public IActionResult GetAll()
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            return Json(new { data = _contenedorTrabajo.Linea.GetAll(a => a.Id_Dist == id_dist) });
        }

        [SessionCheck]
        public JsonResult ExisteFolio(int id)
        {

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc = _contenedorTrabajo.Linea.GetAll(a => a.Id_Dist == id_dist).LastOrDefault();
            int folio = 0;
            if (objDoc != null) folio = objDoc.Id + 1; else folio = 1;

            var objLinea= _contenedorTrabajo.Linea.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objLinea == null)
            {
                return Json(new { existe = false });
            }
            else
            {
                return Json(new { existe = true, folio = folio });
            }
        }

        [SessionCheck]
        public JsonResult CambiaEstatus(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc = _contenedorTrabajo.Linea.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDoc != null)
            {
                objDoc.Activo = objDoc.Activo == true ? false : true;
                _contenedorTrabajo.Linea.Update(objDoc);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "No se encontro Linea" });
        }



        #endregion
    }
}
