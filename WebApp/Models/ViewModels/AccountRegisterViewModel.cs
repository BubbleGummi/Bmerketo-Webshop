using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identities;

namespace WebApp.Models.ViewModels;

public class AccountRegisterViewModel
{
    [Display(Name = "First Name *")]
    [Required(ErrorMessage = "You must enter your first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name *")]
    [Required(ErrorMessage = "You must enter your last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name *")]
    [Required(ErrorMessage = "You must enter your street name")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "Postal Code *")]
    [Required(ErrorMessage = "You must enter your postal code")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "Phone number")]

    public string? PhoneNumber { get; set; }

    [Display(Name = "Company")]
    public string? CompanyName { get; set; }



    [Display(Name = "E-mail *")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter your E-mail address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid E-mail address")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password *")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be between 8 and 15 characters and contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password *")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must confirm your password")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Paste profile image url")]
    [DataType(DataType.Upload)]
    public string? ImageFile { get; set; }

    [Display(Name = "I have read and accepts the terms and conditions")]
    [Required(ErrorMessage = "You must accept the terms and conditions")]
    public bool TermsAndConditions { get; set; } = false;



    public static implicit operator AppUser(AccountRegisterViewModel model)
    {
        return new AppUser
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.CompanyName,

        };
    }

    public static implicit operator AddressEntity(AccountRegisterViewModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
        };
    }


}
