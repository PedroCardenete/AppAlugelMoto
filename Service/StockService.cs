using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class StockService
{

    private readonly IStockRepository _stockRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public StockService(IStockRepository stockRepository, IVehicleRepository vehicleRepository)
    {
        _stockRepository = stockRepository;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<Stock>> GetAllStocksAsync()
    {
        return await _stockRepository.GetAllAsync();
    }

    public async Task<Stock> GetStockByIdAsync(int id)
    {
        return await _stockRepository.GetByIdAsync(id);
    }

    public async Task AddStockAsync(Stock stock)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(stock.VehicleId);
        if (vehicle == null)
        {
            throw new InvalidOperationException("Moto não encontrada.");
        }

        await _stockRepository.AddAsync(stock);
    }

    public async Task UpdateStockAsync(Stock stock)
    {
        await _stockRepository.UpdateAsync(stock);
    }

    // public async Task DeleteStockAsync(int id)
    // {
    //     var stock = await _stockRepository.GetByIdAsync(id);
    //     if (stock != null)
    //     {
    //         await _stockRepository.DeleteAsync(stock);
    //     }
    // }
}