using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Book;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BookTeste : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        private IRepository<BookEntity> _repository;

        public BookTeste(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste Busca livro por nome")]
        [Trait("GET", "BookEntity")]
        public async Task Get_Book_For_Name()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                //Arrange
                BookEntity _entity = new BookEntity()
                {
                    Id = 1,
                    Name = "teste",
                    Price = "55.00",
                    Specifications =
                    {
                        OriginallyPublished = "05/05/2000",
                        Author = "Teste_Author",
                        PageCount = "100",
                        Illustrator = "teste_Illustrator",
                        Genres= "fiction"
                    }
                };

                //Act
                var GetBook = await _repository.SearchBookForNameAsync(_entity.Name);

                //Assert
                Assert.NotNull(GetBook);
                Assert.Equal("teste", GetBook.Name);
                Assert.True(GetBook.Id == 1);
            }
        }
    }
}
