using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.specifications;

namespace Core.interfaces
{
    public interface IGenericRepostiory<T> where T : BaseEntity
    {
        Task<T> GetProductByIdAsync(int id);

        Task<IReadOnlyList<T>> GetProductsAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}