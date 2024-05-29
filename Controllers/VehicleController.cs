using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TestApplication.Model;
using TestApplication.Repositories;
using TestApplication.Repositories.Interfaces;
using TestApplication.Service;

namespace TestApplication.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        
        //Acesso apenas com usuario ADM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return Ok( await _vehicleService.GetAllVehiclesAsync());
        }

        //Acesso apenas com usuario ADM
        [Route("api/vehicle/plate")]
        public async Task<ActionResult<Vehicle>> GetVehicleByPlate(string plate)
        {
            var vehicle = await _vehicleService.GetVehicleByPlateAsync(plate);
            return Ok(vehicle);
        }

        //Acesso apenas com usuario ADM
        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            await _vehicleService.AddVehicleAsync(vehicle);
            return Ok();
        }

        //Acesso apenas com usuario ADM
        [HttpPut]
        public async Task<ActionResult<Vehicle>> UpdateVehicle(Vehicle vehicle)
        {
            var response = await _vehicleService.UpdateVehicleAsync(vehicle);
            return Ok(response);
        }

        //Acesso apenas com usuario ADM
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (await _vehicleService.DeleteVehicleAsync(id))
            {
                return Ok();
            }
            return NoContent();
        }
    }
}