using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StajTakipUygulaması.Controllers
{
	[AllowAnonymous]
	public class Home : Controller
	{
		//Ana Sayfa Fonksiyonu
		public IActionResult Main()
		{
			return View();
		}
	}
}
