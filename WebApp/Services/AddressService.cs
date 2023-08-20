using WebApp.Models.Entities;
using WebApp.Models.Identities;
using WebApp.Repositories;

namespace WebApp.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepo;
    private readonly UserAddressRepository _userAddressRepo;

    public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userAddressRepo = userAddressRepo;
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
    {
        var entity = await _addressRepo.GetAsync(x => 
        x.StreetName == addressEntity.StreetName &&
        x.City == addressEntity.City &&
        x.PostalCode == addressEntity.PostalCode
        );

        
       entity = await _addressRepo.AddAsync(addressEntity);
       return entity!;
            
    }

    public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
    {
        await _userAddressRepo.AddAsync(new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = addressEntity.Id
        });

    }
}
