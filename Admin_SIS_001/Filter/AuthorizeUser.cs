using Admin.AccesoDatos.Data;
using Admin.AccesoDatos.Data.Repository;
using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_SIS_001.Filter
{


    public class AuthorizeUser : ActionFilterAttribute
    {
        private Tbl_GEN_USUARIOS oUsuario;
        //PermissionRepository repository;
        //private MiSistemaEntities db = new MiSistemaEntities();
        //private readonly IContenedorTrabajo _contenedorTrabajo;
        public string[] Roles { get; set; }

        //public AuthorizeUser()
        //{
           
        //}

        public AuthorizeUser(params string[] roles)
        {
            Roles = roles;

            //_contenedorTrabajo = contenedorTrabajo;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            decimal id_dist = decimal.Parse(context.HttpContext.Session.GetString("id_dist"));
            var db = (ContenedorTrabajo)context.HttpContext.RequestServices.GetService(typeof(IContenedorTrabajo));

            var objUser = db.Usuario.GetAll(x => x.Id_Dist == id_dist);
          //var obj=  db.Almacen.getAll();

            //string signInPageUrl = "/Cliente/UserAccess/SignIn";
            string notAuthorizedUrl = "/Cliente/UsersAccess/NotAuthorized";

            //if (context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (Roles.Length > 0)
            //    {
            //        bool userHasRole = false;
            //        foreach (var item in Roles)
            //        {
            //            if (context.HttpContext.User.IsInRole(item))
            //            {
            //                userHasRole = true;
            //            }
            //        }
            //        if (userHasRole == false)
            //        {
            //            if (context.HttpContext.Request.IsAjaxRequest())
            //            {
            //                context.HttpContext.Response.StatusCode = 401;
            //                JsonResult jsonResult = new JsonResult(new { redirectUrl = notAuthorizedUrl });
            //                context.Result = jsonResult;
            //            }

            //            else
            //            {
            //                context.Result = new RedirectResult(notAuthorizedUrl);
            //            }
            //        }
            //    }

            //}
            //else
            //{
            //    if (context.HttpContext.Request.IsAjaxRequest())
            //    {
            //        context.HttpContext.Response.StatusCode = 403;
            //        JsonResult jsonResult = new JsonResult(new { redirectUrl = signInPageUrl });
            //        context.Result = jsonResult;
            //    }
            //    else
            //    {
            //        context.Result = new RedirectResult(signInPageUrl);
            //    }
            //}


            context.Result = new RedirectResult(notAuthorizedUrl);

        }



    }

    public static class AjaxRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return (request.Headers["X-Requested-With"] == "XMLHttpRequest");
            }

            return false;
        }
    }
}
