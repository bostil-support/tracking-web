using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Models;
using Tracking.Web.Data;

namespace Tracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private IInterventionRepository _repository;

        public HomeController(IInterventionRepository repo)
        {
            _repository = repo;
        }

        [Authorize]
        public IActionResult Index()
        {
            var list = _repository.GetAll();
            
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Show(int id)
        {
            var survey = _repository.GetSurveyById(id);
            return View(survey);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
