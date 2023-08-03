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
		[HttpGet]
		public IActionResult AddCar()
		{

			return View();
		}
		[HttpPost]
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
		public IActionResult GetCar(int ID)
		{
			var x = CarsRepostories.getT(ID);
			Cars cr = new Cars()
			{
				CarMark = x.CarMark,
				CarModel= x.CarModel,
				ModelYear=x.ModelYear,
				Price=x.Price,
			};
			return View(x);
		}
		[HttpPost]
		public IActionResult UpdateCar(Cars cr)
		{
			var x = CarsRepostories.getT(cr.id);
			x.CarMark = cr.CarMark;
			x.CarModel = cr.CarModel;
			x.ModelYear = cr.ModelYear;
			x.Price = cr.Price;
			CarsRepostories.TUpdate(x);
			return RedirectToAction("Index");
		}
	}
}
