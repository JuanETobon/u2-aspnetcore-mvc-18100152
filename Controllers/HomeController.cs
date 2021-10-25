using ExamenU2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ListaObjetos");
        }

        public IActionResult AgregarObjeto() { 
        
            return View();
        }
        [HttpPost]
        public IActionResult AgregarObjeto(Mascota miMascota)
        {
            if (ModelState.IsValid)
            {
                Datos.AgregarObjeto(miMascota);
                return RedirectToAction("ListaObjetos");
            }
            else
            {
                return View();
            }
        }
        public IActionResult CargarObjetos() {

            Datos.AgregarObjeto(new Mascota {Id=1,Tipo="Perro",Raza="Husky", Nombre="Pluto",Edad=5 });
            Datos.AgregarObjeto(new Mascota { Id = 2, Tipo = "Conejo", Raza = "Salvaje", Nombre = "Bugs", Edad = 4 });
            Datos.AgregarObjeto(new Mascota { Id = 3, Tipo = "Ave", Raza = "Canario", Nombre = "Piolin", Edad = 2 });
            Datos.AgregarObjeto(new Mascota { Id = 4, Tipo = "Ave", Raza = "Pato", Nombre = "Lucas", Edad = 4 });
            Datos.AgregarObjeto(new Mascota { Id = 5, Tipo = "Raton", Raza = "Mexicano", Nombre = "Speedy", Edad = 5 });
            return RedirectToAction("ListaObjetos");
        }

        public IActionResult ListaObjetos()
        {
            return View(Datos.Objetos);
        }

        public IActionResult EditarObjeto(int Id) {

            Mascota miMascota = Datos.Objetos.Where(m => m.Id== Id).FirstOrDefault();

            return View(miMascota);

        }
        [HttpPost]
        public IActionResult EditarObjeto(Mascota miMascota)
        {
            Mascota m = Datos.Objetos.Where(m => m.Id == miMascota.Id).FirstOrDefault();
            m.Nombre = miMascota.Nombre;
            m.Raza = miMascota.Raza;
            m.Tipo = miMascota.Tipo;
            m.Edad = miMascota.Edad;

            return RedirectToAction("ListaObjetos");
        }

        public IActionResult EliminarObjeto(int Id)
        {
            Mascota miMascota = Datos.Objetos.Where(m => m.Id == Id).FirstOrDefault();

            return View(miMascota);
        }

        public IActionResult ConfirmacionEliminar(int Id)
        {
            Mascota miMascota = Datos.Objetos.Where(m => m.Id == Id).FirstOrDefault();

            Datos.EliminarObjeto(miMascota);

            return RedirectToAction("ListaObjetos");
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
}
