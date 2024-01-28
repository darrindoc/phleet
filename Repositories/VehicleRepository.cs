using Microsoft.AspNetCore.Mvc;
using Phleet.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Phleet.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IConfiguration _config;

        public VehicleRepository(IConfiguration config) 
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Vehicle> GetAllVehicles()
        {
            using (SqlConnection conn = Connection) 
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) 
                {
                    cmd.CommandText = @"
                        SELECT id, Description, make, model, year, plate, mileage
                        FROM Vehicle";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Vehicle> vehicles = new List<Vehicle>();
                    while (reader.Read()) 
                    {
                        Vehicle vehicle = new Vehicle
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Make = reader.GetString(reader.GetOrdinal("Make")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            Year = reader.GetString(reader.GetOrdinal("Year")),
                            Plate = reader.GetInt32(reader.GetOrdinal("Plate")),
                            Mileage = reader.GetInt32(reader.GetOrdinal("Mileage")),
                            //Maintenance goes here
                        };
                        vehicles.Add(vehicle);
                    }
                    reader.Close();
                    return vehicles;
                }
            }
        }

    }
}
