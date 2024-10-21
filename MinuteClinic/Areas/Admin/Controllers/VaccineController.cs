using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            
            var vaccines = context.Vaccines
                                  .Include(v => v.Clinic)
                                  .Include(v => v.Providers)
                                  .OrderBy(v => v.Name)  // Optional: order by name
                                  .ToList();
            return View(vaccines);
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

        
    }
}
