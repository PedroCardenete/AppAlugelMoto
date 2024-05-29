using TestApplication.Model;

namespace TestApplication.Repositories.Interfaces;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    public  Task<Vehicle> GetByLicensePlateAsync(string licensePlate);
}