using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestApplication.Data;
using TestApplication.Repositories.Interfaces;
using TestApplication.Repositories.Interfaces;
using TestApplication.Model;

namespace TestApplication.Repositories;

public class UserRepository : IUserRepository
    

{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async Task<User> AddAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }


    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void CheckExtensionImageCnh(IFormFile file)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }
}