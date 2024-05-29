using System.Linq.Expressions;
using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Repositories;

public class StockRepository : IStockRepository
{
    public Task<IEnumerable<Stock>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Stock> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Stock> AddAsync(Stock entity)
    {
        throw new NotImplementedException();
    }

    public Task<Stock> UpdateAsync(Stock entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}