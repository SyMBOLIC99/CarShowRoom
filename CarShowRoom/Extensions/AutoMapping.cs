using AutoMapper;
using CarShowRoom.Models.DTO;
using CarShowRoom.Models.DTO.Models;
using CarShowRoom.Models.Requests;
using CarShowRoom.Models.Responses;

namespace CarShowRoom.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Car, CarResponse>().ReverseMap();
            CreateMap<CarRequest, Car>().ReverseMap();
            CreateMap<Car, CarUpdateRequest>();
            CreateMap<Shift, ShiftResponse>().ReverseMap();
            CreateMap<ShiftRequest, Shift>().ReverseMap();
            CreateMap<Shift, ShiftUpdateRequest>();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeRequest, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequest>();
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<ClientRequest, Client>().ReverseMap();
            CreateMap<Client, ClientUpdateRequest>();
        }
    }
}
