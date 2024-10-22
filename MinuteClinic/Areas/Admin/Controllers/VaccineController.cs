using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinuteClinic.Models;

namespace MinuteClinic.Areas.Admin.Controllers
{
    

    [Area("Admin")]
    public class VaccineController : Controller
    {
        private MinuteClinicContext context { get; set; }

        public VaccineController(MinuteClinicContext ctx) => context = ctx;
    

    // GET: VaccineController
    [Route("Admin/Vaccine")]
        public IActionResult Index(int? ClinicId, int? ProviderId)
        {
            // Fetch the clinics and providers
            var clinics = context.Clinics.ToList();
            var providers = context.Providers.ToList();

            // Populate the ViewBag with SelectList items for the dropdowns
            ViewBag.ClinicList = new SelectList(clinics, "ClinicId", "ClinicName", ClinicId);
            ViewBag.ProviderList = new SelectList(providers, "ProviderId", "Name", ProviderId);

            // Fetch vaccines with optional filtering
            var vaccines = context.Vaccines
                                   .Include(v => v.Clinic)
                                   .Include(v => v.Providers)
                                   .AsQueryable();

            // Apply filtering if ClinicId or ProviderId is provided
            if (ClinicId.HasValue)
            {
                vaccines = vaccines.Where(v => v.ClinicId == ClinicId.Value);
            }

            if (ProviderId.HasValue)
            {
                vaccines = vaccines.Where(v => v.ProviderId == ProviderId.Value);
            }

            return View(vaccines.ToList());
        }

        [Route("Admin/Vaccine/create")]
        public ActionResult Create()
        {
            ViewBag.clinic = context.Clinics.OrderBy(g => g.ClinicName).ToList();
            ViewBag.provider = context.Providers.OrderBy(g => g.Name).ToList();

            var availableTimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

            ViewBag.TimeSlots = availableTimeSlots;

            return View();
        }

        [HttpPost]
        [Route("Admin/Vaccine/create")]
        public ActionResult Create(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                context.Vaccines.Add(vaccine);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Vaccine has been added successfully!";

                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.clinic = context.Clinics.OrderBy(g => g.ClinicName).ToList();
                ViewBag.provider = context.Providers.OrderBy(g => g.Name).ToList();
                var availableTimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

                ViewBag.TimeSlots = availableTimeSlots;
                return View(vaccine);
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var vaccine = context.Vaccines.Find(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            context.Vaccines.Remove(vaccine);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Delete successfully!";

            return RedirectToAction("Index");
        }


    }
}
