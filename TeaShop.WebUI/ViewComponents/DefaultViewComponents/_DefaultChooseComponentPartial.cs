using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultChooseComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
