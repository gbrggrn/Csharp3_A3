using Csharp3_A3.Models;
using Csharp3_A3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Csharp3_A3.Controllers
{
	public class AccountController : Controller
	{
		private readonly AccountService _accountService;

		public AccountController(AccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Privacy()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginInput input)
		{
			var user = await _accountService.AuthenticateAsync(input.Username, input.Password);

			if (user == null)
			{
				ModelState.AddModelError("", "Invalid");
				return View();
			}

			var claims = new List<Claim>
			{
				new(ClaimTypes.Name, user.Username),
				new(ClaimTypes.Role, user.Role)
			};

			var identity = new ClaimsIdentity(claims, "CookieAuth");
			var principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync("CookieAuth", principal);

			if (user.Role == "Patient")
			{
				return RedirectToAction("PatientPortal", "Patient");
			}
			else
			{
				return RedirectToAction("StaffDashboard", "StaffPages");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("CookieAuth");
			return RedirectToAction("Index", "Home");
		}
	}
}
