using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.Models.Requests
{
    public  class ClientRequest
    {
        
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<Car> RecommendedCar { get; set; }
    }
}
