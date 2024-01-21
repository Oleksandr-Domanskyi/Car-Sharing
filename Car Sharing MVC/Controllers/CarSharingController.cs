using Microsoft.AspNetCore.Mvc;

namespace Car_Sharing_MVC.Controllers
{
    public class CarSharingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
