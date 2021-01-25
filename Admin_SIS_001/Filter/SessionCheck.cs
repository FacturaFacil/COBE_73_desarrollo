using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_SIS_001.Filter
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            if (actionExecutingContext.HttpContext.Session.GetString("objDistribuidor") == null)
            {
                actionExecutingContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                   
                    area = "Login",
                    controller = "Login",
                    action = "Index",
                    //returnurl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(actionExecutingContext.HttpContext.Request)
                    //returnurl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(actionExecutingContext.HttpContext.Request)
                }));
            }           
        }
    }
}
