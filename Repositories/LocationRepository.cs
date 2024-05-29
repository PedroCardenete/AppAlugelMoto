using System.Linq.Expressions;
using TestApplication.Data;
using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Repositories;

public class LocationRepository : ILocationRepository
{
    
    private readonly AppDbContext _dbContext;

    public LocationRepository (AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public Task<IEnumerable<Location>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Location> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Location> AddAsync(Location entity)
    {
        throw new NotImplementedException();
    }

    public Task<Location> UpdateAsync(Location entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> ContainsLocationByVehicleAsync(int vehicleId)
    {
        if (_dbContext.Locations.Where(l => l.VehicleId == vehicleId).Count() > 1)
        {
            return true;
        }
        return false;
    }
}