using System.Collections.Generic;

namespace CarShowRoom.Models.DTO.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public double Balance { get; set; }
        public List<Car> RecommendedCar { get; set; }
    }
}
