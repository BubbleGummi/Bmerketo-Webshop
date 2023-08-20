using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identities;

namespace WebApp.Controllers;

public class Logoutcontroller : Controller
{

    private readonly SignInManager<AppUser> _signInManager;

    public Logoutcontroller(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        if(_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();
        
        return LocalRedirect("/");
    }
}
