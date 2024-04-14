using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyoutComponents
{
    public class _UILeyoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
