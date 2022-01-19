using AutoMapper;
using CarShowRoom.Models.DTO;
using CarShowRoom.Models.Requests;
using CarShowRoom.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Car, CarResponse>().ReverseMap();
            CreateMap<CarRequest, Car>().ReverseMap();
            CreateMap<Car, CarUpdateRequest>();
        }
    }
}
