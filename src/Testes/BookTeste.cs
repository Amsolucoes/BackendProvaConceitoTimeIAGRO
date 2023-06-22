using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BookTeste : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IRepository<BookEntity> _repository;

        public BookTeste(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste Busca livro por nome")]
        [Trait("GET", "BookEntity")]
        public async Task Get_Book_For_Name_Success()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                //Arrange
                CreateBookEntity();

                //Act
                var GetBook = await _repository.SearchBookForNameAsync(CreateBookEntity()?.Name);

                //Assert
                Assert.NotNull(GetBook);
                Assert.Equal("teste", GetBook.Name);
                Assert.True(GetBook.Id == 1);
            }
        }

        [Fact(DisplayName = "Teste Busca livro por author")]
        [Trait("GET", "BookEntity")]
        public async Task Get_Book_For_Author_Success_Asc()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                //Arrange
                CreateBookEntity();

                //Act
                var GetBookAuthor = await _repository.SearchBookForAuthorPriceAsync(CreateBookEntity()?.Specifications?.Author, 0);
                var FirstGetBookAuthor = GetBookAuthor.FirstOrDefault();

                //Assert
                Assert.NotNull(GetBookAuthor);
                Assert.Equal("Teste_Author", FirstGetBookAuthor.Specifications.Author);
                Assert.True(FirstGetBookAuthor?.Id == 1);
            }
        }

        [Fact(DisplayName = "Teste Calcular taxa 20%")]
        [Trait("GET", "BookEntity")]
        public async Task Get_Calculate_Success()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                //Arrange
                CreateBookEntity();

                //Act
                var GetCalculate = await _repository.CalculateDelivery(CreateBookEntity()?.Name);

                //Assert
                Assert.NotNull(GetCalculate);
                Assert.Equal("Teste_Author", GetCalculate?.Specifications?.Author);
                Assert.NotEqual(GetCalculate.Price, CreateBookEntity().Price);
                Assert.True(GetCalculate?.Id == 1);
            }
        }

        private BookEntity CreateBookEntity()
        {
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
                        Genres= "fiction, action"
                    }
            };
            return _entity;
        }
    }
}
