using Microsoft.EntityFrameworkCore;
using Products.Application.Contracts.Persistence;
using Products.Domain.Entites;
using Products.Domain.Entities;

namespace Products.Persistence.Repositories
{

    public class SizeRepository : BaseRepository<MainSize>, ISizeRepository
    {
        public SizeRepository(ProductDbContext productDbContext) : base(productDbContext)
        {

        }
        public async Task<IReadOnlyList<MainSize>> GetAllSizeAsync()
        {
            List<MainSize> allPosts = new List<MainSize>();
            //  allPosts = includeCategory ? await _dbContext.Products.Include(x => x.Category).ToListAsync() : await _dbContext.Posts.ToListAsync();
            allPosts = await _dbContext.MainSizes.ToListAsync();
            return allPosts;
        }

        public async Task<MainSize> GetSizeByIdAsync(Guid id)
        {
            MainSize Post = new MainSize();
            Post = await GetByIdAsync(id);
            return Post;
        }
    }

}
