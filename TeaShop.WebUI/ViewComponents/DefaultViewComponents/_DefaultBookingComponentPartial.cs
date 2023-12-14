using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBookingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}