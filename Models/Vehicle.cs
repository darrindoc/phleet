using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace Phleet.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string ?Description { get; set; }
        public string ?Make { get; set; }
        public string ?Model { get; set; }
        public string Year { get; set; }
        public int ?Plate { get; set; }
        public int Mileage { get; set; }
        //Maintenance goes here


    }
}
