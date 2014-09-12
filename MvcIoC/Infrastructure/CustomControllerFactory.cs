using MvcIoC.Controllers;
using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var repository = new ProteinRepository( );
                var service = new ProteinTrackingService(repository);
                var controller = new ProteinTrackerController(service);
                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var dispose = controller as IDisposable;
            if(dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}