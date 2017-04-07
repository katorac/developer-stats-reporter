using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using developer_stats_reporter.Models.Operations;

namespace developer_stats_reporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatOperations _statOperations;

        public HomeController(IStatOperations statOperations)
        {
            _statOperations = statOperations;
        }

        public ActionResult Index()
        {
            var countries = _statOperations.GetCountries();

            return View(countries);
        }
    }
}