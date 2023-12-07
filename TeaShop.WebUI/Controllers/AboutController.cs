using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
