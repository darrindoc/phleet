using Phleet.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Phleet.Repositories
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
    }
}
