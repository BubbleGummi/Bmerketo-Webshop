using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(UserContext context) : base(context)
        {
        }
    }
}
