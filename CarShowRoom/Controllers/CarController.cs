using AutoMapper;
using CarShowRoom.BL.Interfaces;
using CarShowRoom.BL.Services;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        
           public CarController(ICarService carService)
        {
            
            _carService = carService;
        }

       
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _carService.GetById(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            var result = _carService.Create(car);

            return Ok(car);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _carService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            var searchTag = _carService.GetById(car.Id);

            if (searchTag == null) return NotFound(car.Id);

            var result = _carService.Update(car);

            return Ok(result);
        }
    }
}

