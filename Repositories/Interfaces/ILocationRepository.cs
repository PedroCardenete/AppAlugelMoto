using TestApplication.Model;

namespace TestApplication.Repositories.Interfaces;

public interface  ILocationRepository : IGenericRepository<Location>
{
    Task<bool> ContainsLocationByVehicleAsync(int vehicleId);
}