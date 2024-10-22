using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MinuteClinic.Models;

namespace MinuteClinic.Controllers;


public class HomeController : Controller
{
    

    [Route("")]
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult ManagePrescription()
    {
        return Content("Manage Prescription Action");
    }
    public ActionResult ManageCart()
    {
        return Content("Shopping Cart Action");
    }
    
    public ActionResult ManagePayment()
    {
        return Content("Insurance and Payment Action");
    }
    public ActionResult Managerecords()
    {
        return Content("Medical records Action");
    }




}
