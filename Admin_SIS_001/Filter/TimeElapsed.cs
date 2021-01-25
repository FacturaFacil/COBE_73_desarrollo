using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_SIS_001.Filter
{
    public class TimeElapsed : Attribute, IActionFilter
    {

        private Stopwatch timer;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = " Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            IActionResult iActionResult = context.Result;
            //((ObjectResult)iActionResult).Value += result;
        }
    }
}
