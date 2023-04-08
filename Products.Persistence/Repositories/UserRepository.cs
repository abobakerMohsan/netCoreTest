//using Microsoft.EntityFrameworkCore;
//using Products.Application.Contracts.Persistence;
//using Products.Domain.Entities;

//namespace Products.Persistence.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
     
//        protected readonly ProductDbContext _dbContext;

//        public UserRepository(ProductDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }


//        public async Task<User> GetByIdAsync(int id)
//        {
//            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
//        }

//        public async Task AddAsync(User user)
//        {
//            await _dbContext.Users.AddAsync(user);

//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
//        {
//            return await _dbContext
//                .Users
//                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
//        }
//    }
//}