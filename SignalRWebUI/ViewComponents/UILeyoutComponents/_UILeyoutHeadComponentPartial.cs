using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyoutComponents
{
    public class _UILeyoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
