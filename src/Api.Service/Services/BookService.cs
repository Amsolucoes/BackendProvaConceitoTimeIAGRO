using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Book;
    
namespace Api.Service.Services
{
    public class BookService : IBookService
    {
        private IRepository<BookEntity> _repository;

        public BookService(IRepository<BookEntity> repository)
        {
            _repository = repository;
        }

        async Task<BaseEntity> IBookService.GetForName(string name)
        {
            return await _repository.SearchBookForNameAsync(name);
        }

        async Task<IEnumerable<BaseEntity>> IBookService.GetForAuthor(string author, int order)
        {
            return await _repository.SearchBookForAuthorPriceAsync(author, order);
        }

        async Task<BaseEntity> IBookService.CalculateDelivery(string name)
        {
            return await _repository.CalculateDelivery(name);
        }
    }
}
