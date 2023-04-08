using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Domain.Entites;
using Products.Domain.Entities;

namespace Products.Application.Contracts.Persistence
{
    public interface ISizeRepository : IAsyncRepository<MainSize>
    {
        Task<IReadOnlyList<MainSize>> GetAllSizeAsync();
        Task<MainSize> GetSizeByIdAsync(Guid id);
    }
}
