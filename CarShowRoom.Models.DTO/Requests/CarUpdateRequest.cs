using CarShowRoom.Models.Enums;

namespace CarShowRoom.Models.Requests
{
    public  class CarUpdateRequest
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public CarFuelType FuelType { get; set; }
        public int Price { get; set; }
    }
}
