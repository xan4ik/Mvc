using Microsoft.AspNetCore.Mvc;
using SietReals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SietReals.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            DbService.Service().ChangeContexTo("Default");
            return View(new DefaultLoadModel(DbService.Service().GetCurrentImage()));
        }
    }
}
