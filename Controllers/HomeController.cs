using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel;
using System.IO.Compression;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers;
//esto se puede modularizar muchisimo
public class HomeController : Controller
{
        private IWebHostEnvironment Enviroment;
        public HomeController(IWebHostEnvironment enviroment)
        {
            Enviroment = enviroment;
        }
        public IActionResult ParaProbarCosas()
        {
            ViewBag.ListadoLibros = BD.ListarLibros();
            return View("ParaProbarCosas");
        }
        public IActionResult Index()
        {
            ViewBag.ListadoLibros = BD.ListarLibros();
            ViewBag.Sesion = BD.HaySesion();
            return View();
        }
        public IActionResult Perfil()
        {
            ViewBag.LibrosGuardados = BD.ListarLibrosdeBiblioteca(BD.UsuarioLogueado.IdUsuario);
            return View("Perfil");
        }

        public IActionResult VerDetalleLibro(int IdLibro)
        {
            ViewBag.ElId = IdLibro;
            ViewBag.Libro = BD.VerInfoLibro(IdLibro);
            ViewBag.Personajes = BD.ListarPersonajes(IdLibro);
            ViewBag.Sesion = BD.HaySesion();
            ViewBag.Calificaciones = BD.ListarComentarios(IdLibro);
            if(BD.HaySesion() == true)
            {
            ViewBag.IdUsu = BD.UsuarioLogueado.IdUsuario;
            }
            return View("VerDetalleLibro");
        }
        public IActionResult VerDetallePersonaje(int IdPersonaje)
        { 
            ViewBag.Personajes = BD.VerInfoPersonaje(IdPersonaje);
            ViewBag.Sesion = BD.HaySesion();
            return View("VerDetallePersonaje");
        }
        public IActionResult AgregarPersonaje(int IdLibro)
        {
            ViewBag.ElId = IdLibro;
            ViewBag.NombreLibro = BD.VerInfoLibro(IdLibro).Nombre;
            ViewBag.ListadoPersonaje = BD.VerInfoPersonaje(IdLibro);
            return View("AgregarPersonaje");
        }

        public IActionResult AgregarLibro()
        {
            if (BD.UsuarioLogueado == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("AgregarLibro");
            }
            
        }
        //mofificar
        public IActionResult AgregarComentario()
        {
            if (BD.UsuarioLogueado == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Comentarios");
            }
        }
        
        public IActionResult CrearCuenta()
        {
            return View("IniciarSesion");
        }
        //modificar
        public IActionResult ModificarUsuario(int Id)
        {
            if (BD.UsuarioLogueado == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("ModificarPerfil");
            }
        }

        [HttpPost]
        public IActionResult GuardarCuenta(Usuario usu)
        {
            BD.CrearUsuario(usu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GuardarLibroEnBiblioteca(int IdUsuario, int IdLibro)
        {
            if(BD.yaestabaguardado(IdUsuario, IdLibro) == false){
                BD.GuardarLibro(IdUsuario, IdLibro);
            }
            else{
                BD.EliminardeGuardado(IdUsuario, IdLibro);
            }
            return RedirectToAction("VerDetalleLibro", new {IdLibro=IdLibro});
        }
        [HttpPost]
        public IActionResult InicioSesion(Usuario usu)
        {
            bool s = BD.InicioSesion(usu);
            if(s == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //q en a view le aparezca algo q le avise que puso mal la contraseña
                return RedirectToAction("CrearCuenta");
            }
        }

        public IActionResult CerrarSesión()
        {
            BD.CerrarSesion();
            return RedirectToAction("Index");
        }
        public IActionResult GuardarCambiosUsuario(Usuario usu, IFormFile FotoDePerfil) 
        { 
            if(FotoDePerfil.Length > 0) 
            { 
                string wwwRootLocal = this.Enviroment.ContentRootPath + @"\wwwroot\img\" + FotoDePerfil.FileName; 
                using (var stream = System.IO.File.Create(wwwRootLocal)) 
                { 
                    FotoDePerfil.CopyToAsync(stream);  
                }  
                usu.FotoDePerfil = FotoDePerfil.FileName;  
            } 
            BD.ModificarUsuario(usu);
            BD.UsuarioLogueado = usu;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult GuardarLibro(Libro Pers, IFormFile Portada, IFormFile Contraportada)
        {
            if(Portada.Length > 0 && Contraportada.Length > 0)
            {
                string wwwRootLocal = this.Enviroment.ContentRootPath + @"wwwroot\img\" + Portada.FileName + Contraportada.FileName;
                using (var stream = System.IO.File.Create(wwwRootLocal))
                {
                    Portada.CopyToAsync(stream);
                    Contraportada.CopyToAsync(stream);
                }
                Pers.Portada = Portada.FileName;
                Pers.Contraportada = Contraportada.FileName;
            }
            BD.AgregarLibro(Pers);
            return RedirectToAction("Index");
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
            return RedirectToAction("VerDetalleLibro", new {IdLibro=Pers.IdLibro});
        }
        //xq acá no es RedirectToAction??
        public IActionResult EliminarPersonaje(int IdPersonaje, int IdLibro)
        {
            ViewBag.Sesion = BD.HaySesion();
            bool si =  BD.HaySesion();
            if(si = true)
            {
                BD.EliminarPersonaje(IdPersonaje);
                VerDetalleLibro(IdLibro);
            }
            return View("VerDetalleLibro");
        }
        public IActionResult EliminarLibro(int IdLibro)
        {
            ViewBag.Sesion = BD.HaySesion();
            BD.EliminarLibro(IdLibro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GuardarComentario(calificacion cal)
        {
           BD.calificacionLibroAjax(cal);
           return RedirectToAction("VerDetalleLibro", new {IdLibro=cal.IdLibro});
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