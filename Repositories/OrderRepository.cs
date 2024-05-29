using System.Linq.Expressions;
using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Repositories;

public class OrderRepository : IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Order> AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}