using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class UILeyoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
