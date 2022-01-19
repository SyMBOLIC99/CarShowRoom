using CarShowRoom.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.Models.Requests
{
   public   class CarRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public CarFuelType FuelType { get; set; }
        public int Price { get; set; }
    }
}
