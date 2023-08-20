using WebApp.Models.Contexts;
using WebApp.Models.Entities;


namespace WebApp.Repositories;

public class TagRepository : DataRepository<TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}
