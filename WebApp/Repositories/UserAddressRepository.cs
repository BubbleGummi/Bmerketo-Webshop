using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(UserContext context) : base(context)
        {
        }
    }
    
    
}
