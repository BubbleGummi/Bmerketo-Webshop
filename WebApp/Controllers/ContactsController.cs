using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactMessageViewModel contactMessageViewModel)
        {
            if(ModelState.IsValid)
            {
                if(await _contactService.SaveContactMessageAsync(contactMessageViewModel))
                    return RedirectToAction("Index", "Contacts");

                ModelState.AddModelError("", "Something went wrong, please try again");
            }
            return View();
        }
    }
}
