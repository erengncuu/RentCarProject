using Microsoft.AspNetCore.Mvc;

namespace RentCarProject.Controllers
{
	public class CarsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
