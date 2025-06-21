using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Web_MVC.Models;
using Api_Flotas.Consumer; // Asegúrate que esta es la clase Crud<T>

namespace Web_MVC.Controllers
{
    public class CamionesController : Controller
    {
        private const string apiUrl = "https://localhost:7235/api/camiones";

        // GET: CamionesController
        public ActionResult Index()
        {
            Crud<Camion>.EndPoint = apiUrl;
            var data = Crud<Camion>.GetAll();
            ViewBag.TotalCamiones = data.Count;
            return View(data);
        }

        // GET: CamionesController/Details/5
        public ActionResult Details(int id)
        {
            Crud<Camion>.EndPoint = apiUrl;
            var camion = Crud<Camion>.GetById(id);
            return View(camion);
        }

        // GET: CamionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CamionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Camion data)
        {
            try
            {
                Crud<Camion>.EndPoint = apiUrl;
                Crud<Camion>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CamionesController/Edit/5
        public ActionResult Edit(int id)
        {
            Crud<Camion>.EndPoint = apiUrl;
            var camion = Crud<Camion>.GetById(id);
            return View(camion);
        }

        // POST: CamionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Camion data)
        {
            try
            {
                Crud<Camion>.EndPoint = apiUrl;
                Crud<Camion>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CamionesController/Delete/5
        public ActionResult Delete(int id)
        {
            Crud<Camion>.EndPoint = apiUrl;
            var camion = Crud<Camion>.GetById(id);
            return View(camion);
        }

        // POST: CamionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Camion data)
        {
            try
            {
                Crud<Camion>.EndPoint = apiUrl;
                Crud<Camion>.Delete(id);
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
