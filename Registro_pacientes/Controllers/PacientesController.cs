using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Registro_pacientes.BaseDeDatos;
using Registro_pacientes.Models;

namespace Registro_pacientes.Controllers
{
    public class PacientesController : Controller
    {
        BD _context = new BD();
        // GET: PacientesController
        public ActionResult Index()
        {
            return View(_context.listarPacientes(0));
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            ViewBag.ObraSocial = new List<SelectListItem>
           {
               new SelectListItem { Text = "OSDE", Value = "OSDE"},
               new SelectListItem { Text = "APROSS", Value = "APROSS"},
               new SelectListItem { Text = "PAMI", Value = "PAMI"},
               new SelectListItem { Text = "OTRO", Value = "OTRO"},
           };
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente pacienteNuevo)
        {
            try
            {
                ViewBag.ObraSocial = new List<SelectListItem>
           {
               new SelectListItem { Text = "OSDE", Value = "OSDE"},
               new SelectListItem { Text = "APROSS", Value = "APROSS"},
               new SelectListItem { Text = "PAMI", Value = "PAMI"},
               new SelectListItem { Text = "OTRO", Value = "OTRO"},
           };
                string mensaje = _context.crearPaciente(pacienteNuevo);
                TempData["Mensaje"] = "Paciente Creado";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
