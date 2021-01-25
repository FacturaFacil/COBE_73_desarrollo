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
    public class INV_MarcasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;

        public INV_MarcasController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor)
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
           var objDoc = _contenedorTrabajo.Marca.GetAll(a => a.id_dist == id_dist).LastOrDefault();
           int folio = 0;         
            if (objDoc != null)folio = objDoc.id + 1; else folio = 1;
            ViewBag.folio = folio;
            return View();
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_INV_MARCAS marca)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {
                
                marca.id_dist = id_dist;              
                _contenedorTrabajo.Marca.Add(marca);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            Tbl_INV_MARCAS marca = new Tbl_INV_MARCAS();
            marca = _contenedorTrabajo.Marca.GetAll(x => x.id == id && x.id_dist == id_dist).FirstOrDefault();

            if (marca == null)
            {
                ViewBag.ErrorTitulo = "No existen Marcas";
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
                //throw new Exception("El objeto marca es null");
            }           
            return View(marca);
        }



        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tbl_INV_MARCAS marca)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {
                marca.id_dist = id_dist;               
                _contenedorTrabajo.Marca.Update(marca);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var marcaDedeBD = _contenedorTrabajo.Marca.GetAll(x => x.id == id && x.id_dist == id_dist).FirstOrDefault();

            if (marcaDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando marca" });
            }

            _contenedorTrabajo.Marca.Remove(marcaDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }



        #region LLAMADAS A LA API

        [SessionCheck]
        [HttpGet]
        public IActionResult GetAll()
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            return Json(new { data = _contenedorTrabajo.Marca.GetAll(a => a.id_dist == id_dist) });
        }

        [SessionCheck]
        public JsonResult ExisteFolio(int id)
        {

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc = _contenedorTrabajo.Marca.GetAll(a => a.id_dist == id_dist).LastOrDefault();
            int folio = 0;
            if (objDoc != null) folio = objDoc.id + 1; else folio = 1;

            var objSuc = _contenedorTrabajo.Marca.GetAll(x => x.id == id && x.id_dist == id_dist).FirstOrDefault();

            if (objSuc == null)
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
            var objDoc = _contenedorTrabajo.Marca.GetAll(x => x.id == id && x.id_dist == id_dist).FirstOrDefault();

            if (objDoc != null)
            {
                objDoc.activo = objDoc.activo == true ? false : true;
                _contenedorTrabajo.Marca.Update(objDoc);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "No se encontro Marca" });
        }



        #endregion
    }
}
