using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Book
{
    public interface IBookService
    {
        public Task<BaseEntity> GetForName(string name);
        public Task<IEnumerable<BaseEntity>> GetForAuthor(string author, int order);
        public Task<BaseEntity> CalculateDelivery(string name);
    }
}
