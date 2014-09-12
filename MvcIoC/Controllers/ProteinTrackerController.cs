using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackingService _proteinTrackingService;
        // GET: ProteinTracker

        public ProteinTrackerController()
        {


        }
        public ProteinTrackerController(IProteinTrackingService proteinTrackingService)
        {
            this._proteinTrackingService = proteinTrackingService;

        }
        public ActionResult Index()
        {
            if (_proteinTrackingService != null) // added for null object reference issue 
            {
                ViewBag.Total = _proteinTrackingService.Total;
                ViewBag.Goal = _proteinTrackingService.Goal;
            }

            return View();

        }

        public ActionResult AddProtein(int iAmount)
        {
            _proteinTrackingService.AddProtein(iAmount);

            ViewBag.Total = _proteinTrackingService.Total;
            ViewBag.Goal = _proteinTrackingService.Goal;

            return View("Index");
        }
    }
}