using Microsoft.AspNetCore.Mvc;
using Phleet.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Phleet.Repositories;

namespace Phleet.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepo;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        public IActionResult Index()
        {
            
            List<Vehicle> vehicles = _vehicleRepo.GetAllVehicles();

            return View(vehicles);
        }
    }

}
