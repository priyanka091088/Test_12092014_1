using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Filters
{
    public class DebugFilter : ActionFilterAttribute
    {
        private IDebugMessageService debugMessageService;

        public DebugFilter(IDebugMessageService iDebugMessageService)
        {
            this.debugMessageService = iDebugMessageService;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(debugMessageService.Message);
        }
    }
}