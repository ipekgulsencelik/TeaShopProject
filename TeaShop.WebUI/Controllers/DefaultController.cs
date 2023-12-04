using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
