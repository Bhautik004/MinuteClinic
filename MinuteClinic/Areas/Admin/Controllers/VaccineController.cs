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
            return View();
        }

        [Route("Admin/Vaccine/create")]
        public ActionResult Create()
        {
            //ViewBag.clinic = context.Clinics.OrderBy(g => g.).ToList();

            return View();
        }

        
    }
}
