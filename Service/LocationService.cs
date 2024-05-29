using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class LocationService
{
        private readonly ILocationRepository _locationRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public LocationService(ILocationRepository locationRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _locationRepository = locationRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            // var vehicle = await _vehicleRepository.GetByIdAsync(location.VehicleId);
            // if (vehicle == null)
            // {
            //     throw new InvalidOperationException("Moto não encontrada.");
            // }
            //
            // var user = await _userRepository.GetByIdAsync(location.UserId);
            // if (user == null || user.TypeCnh != "A")
            // {
            //     throw new InvalidOperationException("Entregador não habilitado para alugar motos.");
            // }
            //
            // location.CreatedDate = DateTime.UtcNow;
            // // location.StartDate = location.CreatedDate.AddDays(1);
            //
            // await _locationRepository.AddAsync(location);
        }

        public async Task ReturnLocationAsync(int id, DateTime returnDate)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                throw new InvalidOperationException("Locação não encontrada.");
            }

            var totalValue = CalculateTotalValue(location, returnDate);
            // location.ReturnDate = returnDate;
            // location.TotalValue = totalValue;

            await _locationRepository.UpdateAsync(location);
        }

        private decimal CalculateTotalValue(Location location, DateTime returnDate)
        {
            // Implementar lógica de cálculo de valor total da locação e multas
            // ...
            return 0;
        }


}
