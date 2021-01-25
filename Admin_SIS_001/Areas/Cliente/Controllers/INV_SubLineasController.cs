using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data;
using Admin.AccesoDatos.Data.Repository;
using Admin.Models;
using Admin.Models.INV.ViewModels;
using Admin_SIS_001.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_SIS_001.Areas.Admin.Controllers
{
    [Area("Cliente")]
    [TypeFilter(typeof(MiExcepciones))]
    public class INV_SubLineasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;

        public INV_SubLineasController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor)
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
            VM_INV_SUBLINEAS _vm = new VM_INV_SUBLINEAS()
            {
                SubLinea = new Tbl_INV_SUBLINEAS(),
                ListaLineas = _contenedorTrabajo.Linea.GetListaLineas(id_dist)
            };
            return View(_vm);
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_INV_SUBLINEAS sublinea)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {

                sublinea.Id_Dist = id_dist;
                _contenedorTrabajo.SubLinea.Add(sublinea);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }


            VM_INV_SUBLINEAS _vm = new VM_INV_SUBLINEAS()
            {
                SubLinea = sublinea,
                ListaLineas = _contenedorTrabajo.Linea.GetListaLineas(id_dist)
            };

            return View(_vm);
        }

        [SessionCheck]
        [HttpGet]

        public IActionResult Edit(string id)
        {

            int id_linea = int.Parse(id.Split("|")[0]);
            int _id = int.Parse(id.Split("|")[1]);


            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            Tbl_INV_SUBLINEAS sublinea = new Tbl_INV_SUBLINEAS();
            sublinea = _contenedorTrabajo.SubLinea.GetAll(x => x.Id == _id && x.Id_Dist == id_dist && x.Id_Linea == id_linea).FirstOrDefault();

            if (sublinea == null)
            {
                ViewBag.ErrorTitulo = "No existe Sublinea";
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
            }
            VM_INV_SUBLINEAS _vm = new VM_INV_SUBLINEAS()
            {
                SubLinea = sublinea,
                ListaLineas = _contenedorTrabajo.Linea.GetListaLineas(id_dist)
            };

            return View(_vm);
        }


        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tbl_INV_SUBLINEAS sublinea)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {
                sublinea.Id_Dist = id_dist;
                _contenedorTrabajo.SubLinea.Update(sublinea);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(sublinea);
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            int id_linea = int.Parse(id.Split("|")[0]);
            int _id = int.Parse(id.Split("|")[1]);

            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var marcaDedeBD = _contenedorTrabajo.SubLinea.GetAll(x => x.Id == _id && x.Id_Dist == id_dist && x.Id_Linea == id_linea).FirstOrDefault();

            if (marcaDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando la Sublinea" });
            }

            _contenedorTrabajo.SubLinea.Remove(marcaDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }



        #region LLAMADAS A LA API

        [SessionCheck]
        [HttpGet]
        public IActionResult GetAll()
        {

            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            return Json(new { data = _contenedorTrabajo.SubLinea.GetAll(a => a.Id_Dist == id_dist, includeProperties: "Lineas").OrderByDescending(x => x.Id_Linea) });
        }

        [SessionCheck]
        public JsonResult ExisteFolio(string param)
        {
            int id_linea = int.Parse(param.Split("|")[0]);
            int id = int.Parse(param.Split("|")[1]);

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc = _contenedorTrabajo.SubLinea.GetAll(a => a.Id_Dist == id_dist && a.Id_Linea == id_linea).LastOrDefault();
            int folio = 0;
            if (objDoc != null) folio = objDoc.Id + 1; else folio = 1;

            var objSubLinea = _contenedorTrabajo.SubLinea.GetAll(x => x.Id == id && x.Id_Dist == id_dist && x.Id_Linea == id_linea).FirstOrDefault();

            if (objSubLinea == null)
            {
                return Json(new { existe = false });
            }
            else
            {
                return Json(new { existe = true, folio = folio });
            }
        }

        [SessionCheck]
        public JsonResult CambiaEstatus(string id)
        {
            int id_linea = int.Parse(id.Split("|")[0]);
            int _id = int.Parse(id.Split("|")[1]);

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc = _contenedorTrabajo.SubLinea.GetAll(x => x.Id == _id && x.Id_Dist == id_dist && x.Id_Linea == id_linea).FirstOrDefault();

            if (objDoc != null)
            {
                objDoc.Activo = objDoc.Activo == true ? false : true;
                _contenedorTrabajo.SubLinea.Update(objDoc);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "No se encontro SubLinea" });
        }



        [SessionCheck]
        public JsonResult ObtenerFolioConsecutivo(int id_linea)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var objDoc =  _contenedorTrabajo.SubLinea.GetAll(a => a.Id_Dist == id_dist && a.Id_Linea == id_linea).LastOrDefault();
            int folio = 0;
            if (objDoc != null)
                folio = objDoc.Id + 1;
            else
                folio = 1;

               
            return Json(new { folio = folio });
           
        }

        #endregion
    }
}
