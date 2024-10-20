using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinuteClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClinicsController : Controller
    {
        // GET: ClinicsController
        [Route("Admin/Clinics")]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
