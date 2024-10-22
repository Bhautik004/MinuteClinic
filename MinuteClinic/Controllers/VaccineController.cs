using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinuteClinic.Controllers
{
   
    public class VaccineController : Controller
    {
        // GET: VaccineController
        public ActionResult Index()
        {
            return Content("VaccineController - Index action placeholder");
        }

    }
}
