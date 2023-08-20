using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class ProductTagRepository : DataRepository<ProductTagEntity>
    {
        public ProductTagRepository(DataContext context) : base(context)
        {
        }
    }


}
