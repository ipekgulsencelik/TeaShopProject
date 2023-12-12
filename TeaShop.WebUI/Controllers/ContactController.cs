using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
