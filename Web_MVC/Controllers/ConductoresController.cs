using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Api_Flotas.Consumer;

namespace Web_MVC.Controllers
{
    public class ConductoresController : Controller
    {
        private const string apiUrl = "https://localhost:7235/api/conductores";

        // GET: Conductores
        public ActionResult Index()
        {
            Crud<Conductor>.EndPoint = apiUrl;
            var data = Crud<Conductor>.GetAll();
            return View(data);
        }

        // GET: Conductores/Details/5
        public ActionResult Details(int id)
        {
            Crud<Conductor>.EndPoint = apiUrl;
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // GET: Conductores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conductor data)
        {
            try
            {
                Crud<Conductor>.EndPoint = apiUrl;
                Crud<Conductor>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Conductores/Edit/5
        public ActionResult Edit(int id)
        {
            Crud<Conductor>.EndPoint = apiUrl;
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // POST: Conductores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conductor data)
        {
            try
            {
                Crud<Conductor>.EndPoint = apiUrl;
                Crud<Conductor>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Conductores/Delete/5
        public ActionResult Delete(int id)
        {
            Crud<Conductor>.EndPoint = apiUrl;
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // POST: Conductores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conductor data)
        {
            try
            {
                Crud<Conductor>.EndPoint = apiUrl;
                Crud<Conductor>.Delete(id);
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
