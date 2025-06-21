using Api_Flotas.Consumer;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_MVC.Controllers
{
    public class MantenimientosController : Controller
    {
        private const string apiMantenimientos = "https://localhost:7235/api/mantenimientos";
        private const string apiCamiones = "https://localhost:7235/api/camiones";
        private const string apiTalleres = "https://localhost:7235/api/talleres";

        public ActionResult Index()
        {
            Crud<Mantenimiento>.EndPoint = apiMantenimientos;
            var data = Crud<Mantenimiento>.GetAll();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            Crud<Mantenimiento>.EndPoint = apiMantenimientos;
            var data = Crud<Mantenimiento>.GetById(id);
            return View(data);
        }

        public ActionResult Create()
        {
            Crud<Camion>.EndPoint = apiCamiones;
            Crud<Taller>.EndPoint = apiTalleres;

            ViewBag.Camiones = Crud<Camion>.GetAll();
            ViewBag.Talleres = Crud<Taller>.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento data)
        {
            try
            {
                Crud<Mantenimiento>.EndPoint = apiMantenimientos;
                Crud<Mantenimiento>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        public ActionResult Edit(int id)
        {
            Crud<Mantenimiento>.EndPoint = apiMantenimientos;
            Crud<Camion>.EndPoint = apiCamiones;
            Crud<Taller>.EndPoint = apiTalleres;

            var data = Crud<Mantenimiento>.GetById(id);
            ViewBag.Camiones = Crud<Camion>.GetAll();
            ViewBag.Talleres = Crud<Taller>.GetAll();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mantenimiento data)
        {
            try
            {
                Crud<Mantenimiento>.EndPoint = apiMantenimientos;
                Crud<Mantenimiento>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        public ActionResult Delete(int id)
        {
            Crud<Mantenimiento>.EndPoint = apiMantenimientos;
            var data = Crud<Mantenimiento>.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Mantenimiento data)
        {
            try
            {
                Crud<Mantenimiento>.EndPoint = apiMantenimientos;
                Crud<Mantenimiento>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
