using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identities;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly AuthService _auth;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(AuthService auth, SignInManager<AppUser> signInManager)
		{
			_auth = auth;
			_signInManager = signInManager;
		}

		#region My Account (//domain.com/account)
		[Authorize]
		//domain.com/account
		public IActionResult Index()
		{
			return View();
		}
		#endregion

		#region Register (//domain.com/account/register)
		//domain.com/register
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(AccountRegisterViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (viewModel.TermsAndConditions != true)
				{
					ModelState.AddModelError("", "You must accept the terms and conditions.");
					return View(viewModel);
				}

				if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
				{
					ModelState.AddModelError("", "An account with this email already exists.");
				}

				if (await _auth.RegisterUserAsync(viewModel))
					return RedirectToAction("LogIn", "Account");
			}

			return View(viewModel);
		}
		#endregion

		#region Login (//domain.com/account/login)
		public IActionResult LogIn(string ReturnUrl = null!)
		{
			var viewModel = new AccountLoginViewModel();

			if (ReturnUrl != null)
				viewModel.ReturnUrl = ReturnUrl;

			return View(viewModel);
		}

		//domain.com/login
		[HttpPost]
		public async Task<IActionResult> LogIn(AccountLoginViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (await _auth.LogInAsync(viewModel))
					return LocalRedirect(viewModel.ReturnUrl);

				ModelState.AddModelError("", "Incorrect Email or Password");
			}

			return View(viewModel);
		}
		#endregion

		#region Logout
		//domain.com/account/logout
		public async Task<IActionResult> LogOut()
		{
			if (_signInManager.IsSignedIn(User))
			{
				await _signInManager.SignOutAsync();
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("Index", "Home");
		}
		#endregion

		#region AccessDenied
		public IActionResult AccessDenied()
		{
			return View();
		}
		#endregion
	}
}
