using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinuteClinic.Controllers
{
    [Area("Main")]
    public class VaccineController : Controller
    {
        // GET: VaccineController
        public ActionResult Index()
        {
            return Content("VaccineController - Index action placeholder");
        }

        // GET: VaccineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VaccineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VaccineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VaccineController/Edit/5
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

        // GET: VaccineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VaccineController/Delete/5
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
