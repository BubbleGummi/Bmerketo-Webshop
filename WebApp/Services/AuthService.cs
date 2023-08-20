using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WebApp.Models.Identities;
using WebApp.Models.ViewModels;

namespace WebApp.Services
{
    public class AuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AddressService _addressService;
        private readonly SeedService _seedService;

        public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, SeedService seedService)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _seedService = seedService;
        }

        // Checks if a user with the given expression already exists
        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        // Registers a new user with the provided view model
        public async Task<bool> RegisterUserAsync(AccountRegisterViewModel viewModel)
        {
            await _seedService.SeedRoles();

            var userRoleName = "user";

            if (!await _userManager.Users.AnyAsync())
            {
                userRoleName = "admin";
            }

            var appUser = new AppUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName, // Set the FirstName property
                LastName = viewModel.LastName,   // Set the LastName property
                // Set other properties of the user here
            };

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, userRoleName);

                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }

            return false;
        }

        // Logs in a user with the provided view model
        public async Task<bool> LogInAsync(AccountLoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                return result.Succeeded;
            }
            return false;
        }
    }
}
