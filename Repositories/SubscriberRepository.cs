using System.Linq.Expressions;
using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Repositories;

public class SubscriberRepository : ISubscriberRepository
    
{
    public Task<IEnumerable<Subscriber>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Subscriber> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Subscriber> AddAsync(Subscriber entity)
    {
        throw new NotImplementedException();
    }

    public Task<Subscriber> UpdateAsync(Subscriber entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}