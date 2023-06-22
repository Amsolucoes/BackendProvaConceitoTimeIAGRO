using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> SearchBookForNameAsync(string name);
        Task<IEnumerable<T>> SearchBookForAuthorPriceAsync(string author, int order);
        Task<BookEntity> CalculateDelivery(string name);
    }
}
