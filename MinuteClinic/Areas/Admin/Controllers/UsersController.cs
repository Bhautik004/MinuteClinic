using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinuteClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        // GET: UsersController
        [Route("Admin/Users")]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
