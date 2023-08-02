using Microsoft.AspNetCore.Mvc;
using RentCarProject.Models;
using RentCarProject.Repostories;

namespace RentCarProject.Controllers
{
	public class CarsController : Controller
	{
		CarsRepostories CarsRepostories = new CarsRepostories();
		Context c = new Context();
		public IActionResult Index()
		{
			
			return View(CarsRepostories.TList());
		}

		public IActionResult AddCar()
		{

			return View();
		}

		public IActionResult AddCar(Cars C)
		{
			CarsRepostories.TAdd(C);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteCar(int Id)
		{
			CarsRepostories.TRemove(new Cars { id = Id });
			return RedirectToAction("Index");
		}
	}
}
