using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data.Repository;
using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.Models;
using Admin.Models.GEN;
using Admin_SIS_001.Filter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Admin_SIS_001.Areas.Admin.Controllers
{
    [Area("Cliente")]
    public class GEN_UsuariosController : Controller
    {
       
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private IHttpContextAccessor _httpContextAccessor;
        public readonly IWebHostEnvironment _hostingEnviroment;

        public GEN_UsuariosController(IContenedorTrabajo contenedorTrabajo, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostingEnviroment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnviroment = hostingEnviroment;
        }


        [SessionCheck]
        //[AuthorizeUser( new[] { "RoleName", "AnotherRoleName" })]
        public IActionResult Index()
        {
           
            return View();
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Create()
        {
           var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            ViewBag.folio = _contenedorTrabajo.Usuario.GetAll(a => a.Id_Dist == id_dist).LastOrDefault().Id + 1;
            return View();
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tbl_GEN_USUARIOS usuario)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var rfc = _contenedorTrabajo.Distribuidor.Get(id_dist).Rfc.ToUpper();

            if (ModelState.IsValid)
                {
                string rutaPrincipal = _hostingEnviroment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                string nombreArchivo = Guid.NewGuid().ToString();
                var subidas = Path.Combine(rutaPrincipal, @"sistemas\" + rfc);
                if (!Directory.Exists(subidas) )
                {
                    Directory.CreateDirectory(subidas);
                }

                var extencion = Path.GetExtension(archivos[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + extencion), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }

                usuario.Id_Dist = id_dist;
                usuario.Foto_Url = string.Format(@"\sistemas\{0}\{1}{2}", rfc, nombreArchivo, extencion);         
                usuario.Activo = true;
                _contenedorTrabajo.Usuario.Add(usuario);


                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                              
            return View(usuario);
        }

        [SessionCheck]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_USUARIOS objsu = _contenedorTrabajo.Usuario.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objsu == null)
            {
                ViewBag.ErrorTitulo = "No existen Usuario";
                ViewBag.ErrorMensaje = "Ha ocurrido un error mientras se procesaba su solicitud. El equipo de soporte es notificado y estamos trabajando para ti.";
                return View("Error", id);
                //throw new Exception("El objeto marca es null");
            }           
            return View(objsu);
        }

        [SessionCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tbl_GEN_USUARIOS usuario)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            var rfc = _contenedorTrabajo.Distribuidor.Get(id_dist).Rfc.ToUpper();

            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnviroment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                
                var objBd = _contenedorTrabajo.Usuario.GetAll(x => x.Id == usuario.Id && x.Id_Dist == id_dist).FirstOrDefault();

                if (archivos.Count > 0)
                {
                    //Editamos imagenes
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"sistemas\" + rfc);
                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas);
                    }

                    var extencion = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtencion = Path.GetExtension(archivos[0].FileName);
                    var rutaImagen = Path.Combine(rutaPrincipal, objBd.Foto_Url.Trim('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //subimos nuevamente el archivo
                    using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtencion), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStream);
                    }

                    usuario.Id_Dist = id_dist;
                    usuario.Foto_Url = string.Format(@"\sistemas\{0}\{1}{2}", rfc, nombreArchivo, nuevaExtencion);                  
                    _contenedorTrabajo.Usuario.Update(usuario);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    usuario.Foto_Url = objBd.Foto_Url;
                }

                usuario.Id_Dist = id_dist;
                _contenedorTrabajo.Usuario.Update(usuario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(usuario);
          
        }


        [SessionCheck]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var id_dist = Decimal.Parse(HttpContext.Session.GetString("id_dist"));
            var objDedeBD = _contenedorTrabajo.Usuario.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objDedeBD == null)
            {
                return Json(new { succes = false, message = "Error borrando marca" });
            }

            _contenedorTrabajo.Usuario.Remove(objDedeBD);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });

        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            return Json(new { data = _contenedorTrabajo.Usuario.GetAll(a => a.Id_Dist == id_dist) });
        }

        public JsonResult ExisteFolio(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_USUARIOS objSuc = _contenedorTrabajo.Usuario.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objSuc == null)
            {
                return Json(new { existe = false });
            }
            else
            {
                return Json(new { existe = true , folio = _contenedorTrabajo.Usuario.GetAll(a => a.Id_Dist == id_dist).LastOrDefault().Id + 1 });
            }
        }

        public JsonResult CambiaEstatus(int id)
        {
            var id_dist = Decimal.Parse(_httpContextAccessor.HttpContext.Session.GetString("id_dist"));
            Tbl_GEN_USUARIOS objUser = _contenedorTrabajo.Usuario.GetAll(x => x.Id == id && x.Id_Dist == id_dist).FirstOrDefault();

            if (objUser != null)
            {
                objUser.Activo = objUser.Activo == true ? false : true;
                _contenedorTrabajo.Usuario.Update(objUser);
                return Json(new { success = true });
            }
            return Json(new { success = false ,message = "No se encontro Usuario" });
        }

        #endregion
    }
}
