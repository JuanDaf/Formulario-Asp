using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            var obj = new Crud();
            return View(obj.SlPersonas().ToList());
        }

        public IActionResult Insertar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insertar(Persona persona)
        {
            if (!ModelState.IsValid)
                return View();

            var obj = new Crud();
            var rpta = obj.GuardarPer(persona);
            if (rpta)
                return RedirectToAction("Index");
            else
                return View();
        }
        public IActionResult Editar(string Cedula)
        {
            var obj = new Crud();
            var rpta = obj.SlPersona(Cedula);
            return View(rpta);
        }
        [HttpPost]
        public IActionResult Editar(Persona persona)
        {
            var obj = new Crud();
            var rpta = obj.EditarPer(persona);
            if (rpta)
                return RedirectToAction("Index");
            else
                return View();
        }

        public IActionResult Eliminar(string Cedula)
        {
            var obj = new Crud();
            var rpta = obj.SlPersona(Cedula);
            return View(rpta);
        }
        [HttpPost]
        public IActionResult Eliminar(Persona persona)
        {
            var obj = new Crud();
            var rpta = obj.EliminarPer(persona.Cedula);
            if (rpta)
                return RedirectToAction("Index");
            else
                return View();
        }
    }
}
