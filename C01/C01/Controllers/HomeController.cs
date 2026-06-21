using C01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace C01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }
    }
}
