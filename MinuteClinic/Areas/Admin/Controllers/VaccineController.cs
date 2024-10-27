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
            // Query to get all clinics and manufacturers for dropdowns
            var clinics = context.Clinics.Select(c => new SelectListItem
            {
                Value = c.ClinicId.ToString(),
                Text = c.ClinicName
            }).ToList();

            var providers = context.Providers.Select(m => new SelectListItem
            {
                Value = m.ProviderId.ToString(),
                Text = m.Name
            }).ToList();

            var vaccinesQuery = context.Vaccines
                .Include(v => v.Clinic)         // Ensure Clinic is loaded
                .Include(v => v.Providers)      // Ensure Providers is loaded
                .AsQueryable();

            if (ClinicId.HasValue)
            {
                vaccinesQuery = vaccinesQuery.Where(v => v.ClinicId == ClinicId.Value);
            }

            if (ProviderId.HasValue)
            {
                vaccinesQuery = vaccinesQuery.Where(v => v.ProviderId == ProviderId.Value);
            }

            var model = new VaccineViewModel
            {
                SelectedClinicId = ClinicId,
                SelectedProviderId = ProviderId,
                Clinics = clinics,
                Providers = providers,
                Vaccines = vaccinesQuery.ToList() // Execute the query to get the filtered vaccines
            };

            return View(model);

        }



        [Route("Admin/Vaccine/create")]
        public IActionResult Create()
        {
            var clinics = context.Clinics.ToList();
            var providers = context.Providers.ToList();

            ViewBag.ClinicList = new SelectList(clinics, "ClinicId", "ClinicName");
            ViewBag.ProviderList = new SelectList(providers, "ProviderId", "Name");

            var availableTimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

            ViewBag.TimeSlots = availableTimeSlots;

            return View();
        }

        [HttpPost]
        [Route("Admin/Vaccine/create")]
        public IActionResult Create(Vaccine vaccine, IFormFile VaccineImage)
        {
            if (ModelState.IsValid)
            {
                if (VaccineImage != null && VaccineImage.Length > 0)
                {
                    // Generate a unique file name to avoid collisions
                    string fileName = Guid.NewGuid() + Path.GetExtension(VaccineImage.FileName);
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VaccineImages", fileName);

                    // Save the file
                    using (var fileStream = new FileStream(uploadPath, FileMode.Create))
                    {
                        VaccineImage.CopyTo(fileStream);
                    }

                    // Set the file name in the model
                    vaccine.VaccineImage = fileName;
                }
                

                // Save to database
                context.Vaccines.Add(vaccine);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Vaccine has been added successfully!";
                return RedirectToAction("Index");
            }

            // Repopulate dropdowns if model validation fails
            ViewBag.ClinicList = new SelectList(context.Clinics, "ClinicId", "ClinicName");
            ViewBag.ProviderList = new SelectList(context.Providers, "ProviderId", "Name");
            ViewBag.TimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

            return View(vaccine);
        }

        [HttpGet]
        [Route("Admin/Vaccine/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var vaccine = context.Vaccines
                                 .Include(v => v.Clinic)
                                 .Include(v => v.Providers)
                                 .FirstOrDefault(v => v.VaccineId == id);

            if (vaccine == null)
            {
                return NotFound();
            }

            // Populate ViewBag for dropdowns
            ViewBag.ClinicList = new SelectList(context.Clinics.OrderBy(c => c.ClinicName), "ClinicId", "ClinicName", vaccine.ClinicId);
            ViewBag.ProviderList = new SelectList(context.Providers.OrderBy(p => p.Name), "ProviderId", "Name", vaccine.ProviderId);

            var availableTimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

            ViewBag.TimeSlots = availableTimeSlots;

            return View(vaccine);
        }

        [HttpPost]
        [Route("Admin/Vaccine/Edit/{id}")]
        public IActionResult Edit(int id, Vaccine vaccine, IFormFile? VaccineImage)
        {
            if (id != vaccine.VaccineId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var originalVaccine = context.Vaccines.AsNoTracking().FirstOrDefault(v => v.VaccineId == id);

                if (VaccineImage != null)
                {
                    
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VaccineImages", originalVaccine.VaccineImage);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    // Save the new image
                    string newFileName = Guid.NewGuid() + Path.GetExtension(VaccineImage.FileName);
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VaccineImages", newFileName);
                    using (var fileStream = new FileStream(uploadPath, FileMode.Create))
                    {
                        VaccineImage.CopyTo(fileStream);
                    }

                    // Update the vaccine record with the new image file name
                    vaccine.VaccineImage = newFileName;
                }
                else
                {
                    // Keep the existing image filename if no new image is uploaded
                    vaccine.VaccineImage = originalVaccine.VaccineImage;
                }



                context.Vaccines.Update(vaccine);
                context.SaveChanges();

                TempData["SuccessMessage"] = "Vaccine details updated successfully!";
                return RedirectToAction("Index");
            }

            // Repopulate dropdowns if ModelState is invalid
            ViewBag.ClinicList = new SelectList(context.Clinics.OrderBy(c => c.ClinicName), "ClinicId", "ClinicName", vaccine.ClinicId);
            ViewBag.ProviderList = new SelectList(context.Providers.OrderBy(p => p.Name), "ProviderId", "Name", vaccine.ProviderId);
            var availableTimeSlots = new Vaccine().AvailableTimeSlots.Split(',');

            ViewBag.TimeSlots = availableTimeSlots;
            return View(vaccine);
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {
            var vaccine = context.Vaccines.Find(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VaccineImages", vaccine.VaccineImage);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);  // Delete the image file
            }
          
            context.Vaccines.Remove(vaccine);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Delete successfully!";
            return RedirectToAction("Index");
        }


    }
}
