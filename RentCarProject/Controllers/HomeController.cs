using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCarProject.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace RentCarProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			
		}
		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}
		[Authorize]
		public IActionResult Security()
		{
			return View();
		}
		[HttpGet("login")]
		public IActionResult Login(string returnUrl)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}
		[HttpPost("login")]
		public async Task<IActionResult> Validate(string username,string password,string returnUrl)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (username=="Sezgin" && password =="12345")
			{
				var claims = new List<Claim>();
				claims.Add(new Claim("username",username));
				claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
				claims.Add(new Claim(ClaimTypes.Name, "Sezgin Eren Göncü"));
				var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var claimPrincipal = new ClaimsPrincipal(claimIdentity);
				await HttpContext.SignInAsync(claimPrincipal);
				return Redirect(returnUrl);
			}
			TempData["Error"] = "Error Username or passordis invalid";
			return View("login");
		}
		[Authorize]
        public async Task<IActionResult> Logout()
		{
		await HttpContext.SignOutAsync();
			return Redirect("/");
			
		} 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}