using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class VehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ILocationRepository _locationRepository;

    public VehicleService(IVehicleRepository vehicleRepository, ILocationRepository locationRepository)
    {
        _vehicleRepository = vehicleRepository;
        _locationRepository = locationRepository;
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
    {
        return await _vehicleRepository.GetAllAsync();
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle == null)
        {
            throw new Exception("Vehicle Not Found");
        }

        return vehicle;
    }

    public async Task<Vehicle> GetVehicleByPlateAsync(string plate)
    {
        var vehicles = await _vehicleRepository.GetByLicensePlateAsync(plate);
        return vehicles;
    }

    public async Task<Vehicle> AddVehicleAsync(Vehicle entity)
    {
        var vehicle = await _vehicleRepository.AddAsync(entity);
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicleAsync(Vehicle entity)
    {
        return await _vehicleRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteVehicleAsync(int id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle != null)
        {
            if (!await _locationRepository.ContainsLocationByVehicleAsync(id))
            {
                await _vehicleRepository.DeleteAsync(vehicle.Id);
                return true;
            }
            else
            {
                throw new InvalidOperationException(
                    "Não é possível deletar a moto pois existem locações associadas a ela.");
            }
        }

        return false;
    }

}