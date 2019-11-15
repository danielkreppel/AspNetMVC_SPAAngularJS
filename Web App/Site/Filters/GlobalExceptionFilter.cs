using Application.Log.Concrete;
using Application.Log.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace Site.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ILog _log = new Log();
            _log.LogError(actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
    }
}