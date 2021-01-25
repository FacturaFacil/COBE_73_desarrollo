using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.AccesoDatos.Data.Repository;
using Admin.Models;
using Admin.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Admin_SIS_001.Areas.Cliente.Controllers
{
    [Area("Login")]
    public class LoginController : Admin.Controllers.BaseController
    {
       

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public LoginController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
          
        }
        public IActionResult Index()
        {
            //DistribuidorVM modelo = new DistribuidorVM();
            //modelo.Distribuidor = _contenedorTrabajo.Distribuidor.
            //HttpContext.Session.Set
            return View();
        }

       

        #region LLAMADAS A LA API

        [HttpGet]
        public IActionResult GetDistribuidor(string rfc)
        {
            //var usuarios = "";

            if (rfc == null)
            {
                return Json(new { success = false, message = "No se encontro distribuidor con ese rfc" });
            }
            var dis = _contenedorTrabajo.Distribuidor.GetAll(x => x.Rfc.ToLower() == rfc.Trim().ToLower()).FirstOrDefault();
            if (dis == null)
            {
                return Json(new { success = false, message = "No se encontro distribuidor con ese rfc" });
            }

            var usuarios = _contenedorTrabajo.Usuario.GetAll(a => a.Id_Dist == dis.Id);
            if (usuarios == null)
            {
                return Json(new { success = false, message = "No se encontro usuario para este rfc" });
            }
            else
            {
                return Json(new { success = true, data = usuarios });
            }


        }


        [HttpPost]
        public JsonResult Login([FromBody] Object usuario)
        {
            //JObject strUser = JObject.Parse(usuario.ToString());
            Tbl_GEN_USUARIOS objUsuario = JsonConvert.DeserializeObject<Tbl_GEN_USUARIOS>(usuario.ToString());

            Tbl_GEN_DISTRIBUIDORES objDistribuidor = _contenedorTrabajo.Distribuidor.Get(objUsuario.Id_Dist);
            Tbl_GEN_USUARIOS user = _contenedorTrabajo.Usuario.GetAll(x => x.Username == objUsuario.Username && x.Id_Dist == objUsuario.Id_Dist).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("id_dist", objUsuario.Id.ToString());
                HttpContext.Session.SetString("objDistribuidor", JsonConvert.SerializeObject(objDistribuidor));
                HttpContext.Session.SetString("objUsuario", JsonConvert.SerializeObject(user));
                return Json(new { success = true, message = "" });
            }
            else
            {
                return Json(new { success = false, message = "Usuario o contraseña incorrecta..." });
            }


        }
        #endregion


        //public T GetObjectFromJson<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);

        //    return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        //}



    }
}
