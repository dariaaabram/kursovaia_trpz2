using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Infrastructure
{
    public class ControllerException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is IndexOutOfRangeException)
            {
                
                exceptionContext.Result = new RedirectResult("/Shared/Error");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}