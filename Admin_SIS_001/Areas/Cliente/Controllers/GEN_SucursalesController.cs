using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data.Repository;
using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.Models;
using Admin.Models.GEN;
using Admin_SIS_001.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Admin_SIS_001.Areas.Admin.Controllers
{
    [Area("Cliente")]
    public class GEN_SucursalesController : Controller
    {
       
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;
         
        public GEN_SucursalesController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor)
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
           var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            ViewBag.folio = _contenedorTrabajo.Sucursal.GetAll(a => a.Id_Dist == id_dist).LastOrDefault().Id + 1;
            return View();
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_GEN_SUCURSALES sucursal)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));

            if (ModelState.IsValid)
                {

                    sucursal.Id_Dist = id_dist;
                    sucursal.Activo = true;
                    _contenedorTrabajo.Sucursal.Add(sucursal);


                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                              
            return View(sucursal);
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_SUCURSALES objsu = _contenedorTrabajo.Sucursal.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objsu == null)
            {
                ViewBag.ErrorTitulo = "No existen Sucursal";
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
                //throw new Exception("El objeto marca es null");
            }           
            return View(objsu);
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tbl_GEN_SUCURSALES sucursal)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {
                sucursal.Id_Dist = id_dist;               
                _contenedorTrabajo.Sucursal.Update(sucursal);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursal);
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var objDedeBD = _contenedorTrabajo.Sucursal.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando marca" });
            }

            _contenedorTrabajo.Sucursal.Remove(objDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }



        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            return Json(new { data = _contenedorTrabajo.Sucursal.GetAll(a => a.Id_Dist == id_dist) });
        }

        public JsonResult ExisteFolio(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_SUCURSALES objSuc = _contenedorTrabajo.Sucursal.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objSuc == null)
            {
                return Json(new { existe = false });
            }
            else
            {
                return Json(new { existe = true , folio = _contenedorTrabajo.Sucursal.GetAll(a => a.Id_Dist == id_dist).LastOrDefault().Id + 1 });
            }
        }

        public JsonResult CambiaEstatus(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_SUCURSALES objSuc = _contenedorTrabajo.Sucursal.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objSuc != null)
            {
                objSuc.Activo = objSuc.Activo == true ? false : true;
                _contenedorTrabajo.Sucursal.Update(objSuc);
                return Json(new { success = true });
            }
            return Json(new { success = false ,message = "No se encontro sucursal" });
        }

        #endregion
    }
}
