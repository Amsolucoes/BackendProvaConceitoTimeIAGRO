using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BookEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> SearchBookForNameAsync(string name)
        {
            return await _dataset.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<IEnumerable<T>> SearchBookForAuthorPriceAsync(string author, int order)
        {
            try
            {
                if (order == 0)
                {
                    return await _dataset.Where(b => b.Specifications.Author == author)
                        .OrderBy(p => p.Price)
                        .ToListAsync();
                }

                return await _dataset.Where(b => b.Specifications.Author == author)
                    .OrderByDescending(p => p.Price)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookEntity> CalculateDelivery(string name)
        {
            try
            {
                BookEntity result = await _dataset.Where(b => b.Name == name).FirstOrDefaultAsync();

                if (result != null)
                {
                    var valuePercent = 20.00;
                    var valueDivision = 100.00;
                    var changeValue = double.Parse(result.Price) / valueDivision;

                    var value = (changeValue * valuePercent) / valueDivision;
                    result.Price = (changeValue + value).ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
