using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.Models.Requests
{
    public  class ClientUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<Car> RecommendedCar { get; set; }
    }
}
