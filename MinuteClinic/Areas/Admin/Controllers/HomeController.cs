    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinuteClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
