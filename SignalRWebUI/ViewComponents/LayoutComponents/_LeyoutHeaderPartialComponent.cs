using Microsoft.AspNetCore.Mvc;
namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LeyoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();//view companentlerin default olrak arandığı yer shered altında olur
            //sınıfın ismi ile aynı olması gereken bir klasör tanımladık
        }
    }
}
