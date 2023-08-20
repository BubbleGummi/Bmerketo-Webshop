using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class ProductRepository : DataRepository<ProductEntity>
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
