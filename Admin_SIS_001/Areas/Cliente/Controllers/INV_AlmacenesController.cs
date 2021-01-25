using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data.Repository;
using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.Models;
using Admin.Models.GEN;
using Admin.Models.INV.ViewModels;
using Admin_SIS_001.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Admin_SIS_001.Areas.Admin.Controllers
{
    [Area("Cliente")]
    public class INV_AlmacenesController : Controller
    {
       
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;
         
        public INV_AlmacenesController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor)
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
            Tbl_INV_ALMACENES objDoc = _contenedorTrabajo.Almacen.GetAll(a => a.Id_Dist == id_dist).LastOrDefault();
            int folio = 0;
            if (objDoc != null)
            {
                folio = objDoc.Id + 1;
            }
            else
            {
                folio = 1;
            }
            ViewBag.folio = folio;

            VM_INV_ALMACENES _vm = new VM_INV_ALMACENES()
            {
                Almacen = new Tbl_INV_ALMACENES(),
                ListaSucursales = _contenedorTrabajo.Sucursal.GetListaSucursales(id_dist)
            };
            return View(_vm);
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_INV_ALMACENES almacen)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));

            if (ModelState.IsValid)
                {

                almacen.Id_Dist = id_dist;              
                    _contenedorTrabajo.Almacen.Add(almacen);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }


            VM_INV_ALMACENES _vm = new VM_INV_ALMACENES()
            {
                Almacen = almacen,
                ListaSucursales = _contenedorTrabajo.Sucursal.GetListaSucursales(id_dist)
            };
            return View(_vm);
            
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //int id_sucursal = int.Parse(param.Split("|")[1]);
            //int id = int.Parse(param.Split("|")[0]);

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_INV_ALMACENES objDoc = _contenedorTrabajo.Almacen.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDoc == null)
            {
                ViewBag.ErrorTitulo = "No existen Alamacen";
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
                //throw new Exception("El objeto marca es null");
            }
            VM_INV_ALMACENES _vm = new VM_INV_ALMACENES()
            {
                Almacen = objDoc,
                ListaSucursales = _contenedorTrabajo.Sucursal.GetListaSucursales(id_dist)
            };
            return View(_vm);
        }
        

       [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VM_INV_ALMACENES _almacen)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            if (ModelState.IsValid)
            {

                _almacen.Almacen.Id_Dist = id_dist;               
                _contenedorTrabajo.Almacen.Update(_almacen.Almacen);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(_almacen);
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //int id_sucursal = int.Parse(param.Split("|")[1]);
            //int id = int.Parse(param.Split("|")[0]);

            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var objDedeBD = _contenedorTrabajo.Almacen.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando Almacén" });
            }

            _contenedorTrabajo.Almacen.Remove(objDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }



        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var datas = _contenedorTrabajo.Almacen.GetAll(a => a.Id_Dist == id_dist, includeProperties: "Sucursal");          
            return Json(new { data = datas });
        }

        public JsonResult ExisteFolio(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_INV_ALMACENES objDoc = _contenedorTrabajo.Almacen.GetAll(a => a.Id_Dist == id_dist).LastOrDefault();
            int folio = 0;
            if (objDoc != null)
            {
                folio = objDoc.Id + 1;
            }
            else
            {
                folio = 1;
            }
         
            Tbl_INV_ALMACENES objSuc = _contenedorTrabajo.Almacen.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objSuc == null)
            {
                return Json(new { existe = false });
            }
            else
            {
                return Json(new { existe = true , folio = folio });
            }
        }

        public JsonResult CambiaEstatus(int id)
        {
            //int id_sucursal = int.Parse(param.Split("|")[1]);
            //int id = int.Parse(param.Split("|")[0]);

            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_INV_ALMACENES objDoc = _contenedorTrabajo.Almacen.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDoc != null)
            {
                objDoc.Activo = objDoc.Activo == true ? false : true;
                _contenedorTrabajo.Almacen.Update(objDoc);
                return Json(new { success = true });
            }
            return Json(new { success = false ,message = "No se encontro Almacén" });
        }

        //public JsonResult ObtenerFolioConsecutivo(int id_sucursal)
        //{
            
        //   var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
        //    Tbl_INV_ALMACENES objDoc = _contenedorTrabajo.Almacen.GetAll(a => a.Id_Dist == id_dist && a.Id_Sucursal == id_sucursal).LastOrDefault();
        //    int folio = 0;
        //    if (objDoc != null)
        //    {
        //        folio = objDoc.Id + 1;
        //    }
        //    else
        //    {
        //        folio = 1;
        //    }

        //    return Json(new { folio = folio });           
            
        //}

        #endregion
    }
}
