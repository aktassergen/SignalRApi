using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyoutComponents
{
    public class _UILeyoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
