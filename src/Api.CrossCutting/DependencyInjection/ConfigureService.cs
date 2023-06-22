using Api.Domain.Interfaces.Services.Book;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBookService, BookService>();
        }
    }
}
