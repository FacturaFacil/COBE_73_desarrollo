using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_SIS_001.Filter
{
    public class MiExcepciones : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IModelMetadataProvider _modelMetadataProvaider;
        public MiExcepciones(IWebHostEnvironment hostEnviroment, IModelMetadataProvider modelMetadataProvaider)
        {
            _hostEnviroment = hostEnviroment;
            _modelMetadataProvaider = modelMetadataProvaider;
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult("Fallo algo en la aplicacion" +
                _hostEnviroment.ApplicationName +
                "La excepcion del tipo: " + context.Exception.GetType());
        }
    }
}
