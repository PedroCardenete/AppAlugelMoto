using Microsoft.EntityFrameworkCore;
using TestApplication.Data;
using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _dbContext;

    public VehicleRepository(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _dbContext.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetByIdAsync(int id)
    {
        var vehicles = await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

        if (vehicles == null)
        {
            throw new Exception("Vehicle Not Found");
        }

        return vehicles;
    }

    public async Task<Vehicle> AddAsync(Vehicle entity)
    {
        await _dbContext.Vehicles.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
        
    }

    public async Task<Vehicle> UpdateAsync(Vehicle entity)
    {
        Vehicle updatedEntity = await GetByIdAsync(entity.Id);

        updatedEntity.Model = entity.Model;
        updatedEntity.UpdateDate = DateTime.Now;
        updatedEntity.Type = entity.Type;
        updatedEntity.Year = entity.Year;
        updatedEntity.LicensePlate = entity.LicensePlate;
        
        _dbContext.Vehicles.Update(updatedEntity);
        await _dbContext.SaveChangesAsync();
        return entity;    
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Vehicle entity)
    {
        _dbContext.Vehicles.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<Vehicle> GetByLicensePlateAsync(string licensePlate)
    {
        return await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
    }
}