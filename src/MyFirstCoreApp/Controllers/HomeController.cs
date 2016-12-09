using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Данный проект представляет собой демонстрацию использования Entity Framework Core 1.0 в рамках ASP.NET Core MVC.";
            ViewData["Contact"] = "Хорошим идеям рады здесь: grindsoul@yandex.ru";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Хорошим идеям рады здесь: grindsoul@yandex.ru";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
