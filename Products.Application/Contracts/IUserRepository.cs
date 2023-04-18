using Products.Domain.Entities;

namespace Products.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task AddAsync(User user);
    }
}