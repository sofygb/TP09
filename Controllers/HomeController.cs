using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers;

public class HomeController : Controller
{
        private IWebHostEnvironment Enviroment;
        public HomeController(IWebHostEnvironment enviroment)
        {
            Enviroment = enviroment;
        }
        public IActionResult Index()
        {
            ViewBag.ListadoLibros = BD.ListarLibros();
            return View();
        }

        public IActionResult VerDetalleLibro(int IdLibro)
        {
            ViewBag.Libro = BD.VerInfoLibro(IdLibro);
            ViewBag.Personajes = BD.ListarPersonajes(IdLibro);
            return View("VerDetalleLibro");
        }
        public IActionResult VerDetallePersonaje(int IdPersonaje)
        { 
            ViewBag.Personajes = BD.VerInfoPersonaje(IdPersonaje);
            return View("VerDetallePersonaje");
        }
        public IActionResult AgregarPersonaje(int IdLibro)
        {
            ViewBag.ListadoPersonaje = BD.VerInfoPersonaje(IdLibro);
            return View("AgregarPersonaje");
        }

        [HttpPost]
        public IActionResult GuardarPersonaje(Personaje Pers, IFormFile Foto)
        {
            if(Foto.Length > 0)
            {
                string wwwRootLocal = this.Enviroment.ContentRootPath + @"wwwroot\img\" + Foto.FileName;
                using (var stream = System.IO.File.Create(wwwRootLocal))
                {
                    Foto.CopyToAsync(stream);
                }
                Pers.Foto = Foto.FileName;
            }

            BD.AgregarPersonaje(Pers);
             ViewBag.Libro = BD.VerInfoLibro(Pers.IdLibro);
            ViewBag.Personajes = BD.ListarPersonajes(Pers.IdLibro);
            return View("VerDetalleLibro");
        }

        public IActionResult EliminarPersonaje(int IdPersonaje, int IdLibro)
        {
            BD.EliminarPersonaje(IdPersonaje);
            VerDetalleLibro(IdLibro);
            return View("VerDetalleLibro");
        }

        public IActionResult EliminarLibro(int IdLibro)
        {
            BD.EliminarLibro(IdLibro);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}

