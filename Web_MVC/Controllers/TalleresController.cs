using Api_Flotas.Consumer;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_MVC.Controllers
{
    public class TalleresController : Controller
    {
        private const string apiUrl = "https://localhost:7235/api/talleres";

        public ActionResult Index()
        {
            Crud<Taller>.EndPoint = apiUrl;
            var data = Crud<Taller>.GetAll();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            Crud<Taller>.EndPoint = apiUrl;
            var data = Crud<Taller>.GetById(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Taller data)
        {
            try
            {
                Crud<Taller>.EndPoint = apiUrl;
                Crud<Taller>.Create(data);
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
            Crud<Taller>.EndPoint = apiUrl;
            var data = Crud<Taller>.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Taller data)
        {
            try
            {
                Crud<Taller>.EndPoint = apiUrl;
                Crud<Taller>.Update(id, data);
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
            Crud<Taller>.EndPoint = apiUrl;
            var data = Crud<Taller>.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Taller data)
        {
            try
            {
                Crud<Taller>.EndPoint = apiUrl;
                Crud<Taller>.Delete(id);
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
