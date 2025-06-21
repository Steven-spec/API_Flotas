using Api_Flotas.Consumer;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_MVC.Controllers
{
    public class AlertasController : Controller
    {
        private const string apiUrlBase = "https://localhost:7235/api/alertas";

        // GET: Alertas
        public ActionResult Index()
        {
            Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
            var data = Crud<AlertaMantenimiento>.GetAll();
            return View(data);
        }

        // GET: Alertas/Details/5
        public ActionResult Details(int id)
        {
            Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
            var data = Crud<AlertaMantenimiento>.GetById(id);
            if (data == null)
                return NotFound();
            return View(data);
        }

        // GET: Alertas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alertas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlertaMantenimiento alerta)
        {
            try
            {
                Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
                Crud<AlertaMantenimiento>.Create(alerta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }

        // GET: Alertas/Edit/5
        public ActionResult Edit(int id)
        {
            Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
            var data = Crud<AlertaMantenimiento>.GetById(id);
            if (data == null)
                return NotFound();
            return View(data);
        }

        // POST: Alertas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlertaMantenimiento alerta)
        {
            try
            {
                Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
                Crud<AlertaMantenimiento>.Update(id, alerta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }

        // GET: Alertas/Delete/5
        public ActionResult Delete(int id)
        {
            Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
            var data = Crud<AlertaMantenimiento>.GetById(id);
            if (data == null)
                return NotFound();
            return View(data);
        }

        // POST: Alertas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlertaMantenimiento alerta)
        {
            try
            {
                Crud<AlertaMantenimiento>.EndPoint = apiUrlBase;
                Crud<AlertaMantenimiento>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }
    }
}
