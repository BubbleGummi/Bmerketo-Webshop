using WebApp.Models.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Services;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveContactMessageAsync(ContactMessageViewModel contactMessageViewModel)
    {
        try
        {
            ContactEntity contactEntity = (ContactEntity)contactMessageViewModel;

            _context.ContactMessages.Add(contactEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
