using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels
{
    public class ContactMessageViewModel
    {
        [Required(ErrorMessage = "You must enter your name")]
        [Display(Name = "Your Name *")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "You must enter your email address")]
        [Display(Name = "Your Email-Address *")]

        public string Email { get; set; } = null!;

        [Display(Name = "Your Phone number")]
        public string? Phone { get; set; }

        [Display(Name = "Your Company Name")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "You must write a message")]
        [Display(Name = "Your Message *")]
        public string Message { get; set; } = null!;


        public static implicit operator ContactEntity(ContactMessageViewModel contactMessageViewModel)
        {
            return new ContactEntity
            {
                Name = contactMessageViewModel.Name,
                Email = contactMessageViewModel.Email,
                Phone = contactMessageViewModel.Phone,
                CompanyName = contactMessageViewModel.CompanyName,
                Message = contactMessageViewModel.Message
            };
        }


    }

}
