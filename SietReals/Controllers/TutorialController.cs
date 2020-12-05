using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SietReals.Models;

namespace SietReals.Controllers
{
    public class TutorialController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            DbService.Service().ChangeContexTo("Default");
            return View(new DefaultLoadModel(DbService.Service().GetCurrentImage()));
        }

    }
}
